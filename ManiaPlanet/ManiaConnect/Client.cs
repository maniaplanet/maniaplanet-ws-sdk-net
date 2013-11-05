using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet.ManiaConnect
{
    public class Client : ManiaPlanetWSSDK.Client
    {
        const string TOKEN_PATH = "/oauth2/token/";

        protected string _loginURL = "https://ws.maniaplanet.com/oauth2/authorize/";
        protected string _logoutURL = "https://ws.maniaplanet.com/oauth2/authorize/logout/";

        public Client(string username = "", string password = "")
            : base(username, password)
        {

        }

        public string GetLoginURL(string scope = null, string redirectURI = null)
        {
            return GetAuthorizationURL(redirectURI, scope);
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
    }
}
