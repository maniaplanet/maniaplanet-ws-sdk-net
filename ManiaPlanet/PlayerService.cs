using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class PlayerService : Client
    {
        public PlayerService(string username = "", string password = "")
            : base(username, password)
        {

        }

        public Task<Player> GetDetails(string login)
        {
            string encodedLogin = System.Net.HttpUtility.UrlEncode(login);
            return Execute<Player>("GET", string.Format("/players/{0}/", encodedLogin));
        }
    }
}
