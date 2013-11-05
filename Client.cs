using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK
{
    public class Client
    {
        protected HttpClient _client;
        private string _username;
        private string _password;
        protected string _baseUrl = "https://ws.maniaplanet.com";

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Client(string username = "", string password = "")
        {
            _client = new HttpClient();
            _username = username;
            _password = password;
        }

        protected void SetAuth()
        {
            String authparam = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(_username + ":" + _password));
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authparam);
        }

        protected void SetHeader()
        {
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("user-agent", "maniaplanet-c#-sdk");
        }

        protected async Task<T> Execute<T>(string method, string url, object content = null)
        {
            string encodedContent = JsonConvert.SerializeObject(content);
            string result;
            SetAuth();
            SetHeader();
            HttpResponseMessage response;

            switch (method)
            {
                case "GET":
                    response = await _client.GetAsync(_baseUrl + url);
                    break;
                case "POST":
                    response = await _client.PostAsync(_baseUrl + url, new StringContent(encodedContent, Encoding.UTF8, "application/json"));
                    break;
                case "DELETE":
                    response = await _client.DeleteAsync(_baseUrl + url);
                    break;
                case "PUT":
                    response = await _client.PutAsync(_baseUrl + url, new StringContent(encodedContent, Encoding.UTF8, "application/json"));
                    break;
                default:
                    throw new NotSupportedException();
            }
            
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new System.Net.Http.HttpRequestException(response.StatusCode.ToString() + " " + response.ReasonPhrase);
            result = response.Content.ReadAsStringAsync().Result;
            if (result == string.Empty)
                return default(T);

            return JsonConvert.DeserializeObject<T>(result);
        }

    }
}
