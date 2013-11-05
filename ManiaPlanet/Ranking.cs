using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class Ranking
    {
        public string environment { get; set; }
        public string unit { get; set; }
        public double points { get; set; }
        public List<Rank> ranks { get; set; }
    }
}
