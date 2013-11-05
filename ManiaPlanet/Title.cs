using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class Title
    {
        public int id { get; set; }
        public string idString { get; set; }
        public string name { get; set; }
        public int isCustom { get; set; }
        public string web { get; set; }
        public string cost { get; set; }
        public string environment { get; set; }
        public List<string> dependencies { get; set; }
    }
}
