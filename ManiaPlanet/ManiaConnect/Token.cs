using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet.ManiaConnect
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires { get; set; }
        public int expires_in { get; set; }
        public string login { get; set; }
        public string refresh_token { get; set; }
        public DateTime Created { get; set; }

        public bool IsExpired
        {
            get
            {
                DateTime created = Created;
                return created.AddSeconds(expires_in - 30).CompareTo(DateTime.Now) < 0;
            }
        }
    }
}
