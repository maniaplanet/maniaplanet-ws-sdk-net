using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class MapVersion
    {
        public int id { get; set; }
        public int mapId { get; set; }
        public Map map { get; set; }
        public string name { get; set; }
        public string link { get; set; }
        public Date date { get; set; }
       // public DateTime dateObject { get; protected set; }
        public int usageCount { get; set; }
    }
}
