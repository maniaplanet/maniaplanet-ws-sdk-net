using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet.ManiaConnect
{
    public class OauthClient : ManiaPlanetWSSDK.Client
    {
        const string TOKEN_PATH = "/oauth2/token/";

        protected string _loginURL = "https://ws.maniaplanet.com/oauth2/authorize/";
        protected string _logoutURL = "https://ws.maniaplanet.com/oauth2/authorize/logout/";
        protected Token _token = null;
        protected string _code;
        protected string _redirectURI;

        protected static IPersistance _persistance;


        static public void SetPersistance(IPersistance persistance)
        {
            OauthClient._persistance = persistance;
        }

        public void SetCode(Uri uri)
        {
            var match = Regex.Match(uri.Query, "code=(\\w*)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                _code = match.Groups[1].Value;
            }
        }

        public string RedirectURI
        {
            get { return _redirectURI; }
            set { _redirectURI = value; }
        }

        public OauthClient(string username = "", string password = "")
            : base(username, password)
        {
            if (_persistance != null)
                _persistance.Init();
        }

        public string GetLoginURL(string scope = null)
        {
            return GetAuthorizationURL(scope);
        }

        public string GetLoginURL(string redirectURI, string scope = null)
        {
            return GetAuthorizationURL(redirectURI, scope);
        }

        public string GetLogoutURL()
        {
            if (_redirectURI == null)
                throw new ArgumentNullException("Set the Redirection URL before using this method");

            return string.Format("{0}?redirect_uri={1}", _logoutURL, HttpUtility.UrlEncode(_redirectURI));
        }

        public string GetLogoutURL(string redirectURI)
        {
            return string.Format("{0}?redirect_uri={1}", _logoutURL, HttpUtility.UrlEncode(redirectURI));
        }

        public void logout()
        {
            _persistance.Destroy();
        }

        protected string GetAuthorizationURL(string scope = "basic")
        {
            if (_redirectURI == null)
                throw new ArgumentNullException("Set the Redirection URL before using this method");

            string queryString = string.Format(
                "client_id={0}&redirect_uri={1}&scope={2}&response_type=code",
                System.Net.HttpUtility.UrlEncode(Username),
                System.Net.HttpUtility.UrlEncode(_redirectURI),
                System.Net.HttpUtility.UrlEncode(scope)
            );
            return _loginURL + "?" + queryString;
        }

        protected string GetAuthorizationURL(string redirectionURI, string scope = "basic")
        {
            string queryString = string.Format(
                "client_id={0}&redirect_uri={1}&scope={2}&response_type=code",
                System.Net.HttpUtility.UrlEncode(Username),
                System.Net.HttpUtility.UrlEncode(redirectionURI),
                System.Net.HttpUtility.UrlEncode(scope)
            );
            return _loginURL + "?" + queryString;

        }

        protected async Task GetAccessToken()
        {
            if (_persistance != null)
            {
                Token token = _persistance.GetVariable<Token>("token");
                if (token != null && !token.IsExpired)
                {
                    _token = token;
                    return;
                }
                else if (token != null && token.refresh_token != null)
                {
                    await GetTokenFromRefreshToken(token.refresh_token);
                    return;
                }
            }

            if (_code == null)
            {
                throw new ArgumentNullException("Code has to be set before getting the token");
            }

            if (_redirectURI == null)
                throw new ArgumentNullException("Set the Redirection URL before using this method");
            await GetTokenFromCode();



        }

        protected async Task GetTokenFromCode()
        {
            await GetTokenFromParamsDictionnary(new Dictionary<string, string>
                {
                    {"client_id",Username},
                    {"client_secret",Password},
                    {"redirect_uri",_redirectURI},
                    {"grant_type","authorization_code"},
                    {"code",_code}
                });
        }

        protected async Task GetTokenFromRefreshToken(string refreshToken)
        {
            await GetTokenFromParamsDictionnary(new Dictionary<string, string>
            {
                {"client_id",Username},
                {"client_secret",Password},
                {"grant_type","refresh_token"},
                {"refresh_token",refreshToken}
            });
        }

        private async Task GetTokenFromParamsDictionnary(Dictionary<string, string> parameters)
        {
            string contentType = ContentType;
            ContentType = "application/x-www-form-urlencoded";
            var queryArray = (from parameter in parameters
                              select string.Format("{0}={1}", parameter.Key, HttpUtility.UrlEncode(parameter.Value))).ToArray();
            string queryString = string.Join("&", queryArray);

            try
            {
                Token token = await Execute<Token>("POST", TOKEN_PATH, queryString);
                token.Created = DateTime.Now;
                _token = token;
                if (_persistance != null)
                    _persistance.SetVariable("token", _token);
            }
            catch (HttpException e)
            {
                string message;
                switch (e.Message)
                {
                    case "invalid_request":
                        message =
                         "invalid_request: The request is missing a required " +
                         "parameter, includes an unsupported parameter or " +
                         "parameter value, or is otherwise malformed.";
                        break;
                    case "invalid_client":
                        message = "invalid_client: Application authentication failed. ";
                        break;

                    case "invalid_grant":
                        message =
                            "invalid_grant: The provided access grant is invalid, " +
                            "expired, or revoked (e.g. invalid assertion, expired " +
                            "authorization token, bad end-user password credentials, " +
                            "or mismatching authorization code and redirection URI).";
                        break;
                    default:
                        throw e;
                }
                throw new HttpException(message, e.StatusCode, e);
            }
            ContentType = contentType;
        }

        protected Task<T> ExecuteOAuth2<T>(string method, string path, object content = null)
        {
            enableAuth = false;
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token.access_token);
            Task<T> result = Execute<T>(method, path, content);
            enableAuth = true;
            return result;
        }

        protected bool IsAccessTokenExpired(Token token)
        {
            if (token == null)
            {
                return true;
            }
            return token.Created.AddSeconds(token.expires_in - 30).CompareTo(DateTime.Now) < 0;
        }
    }
}
