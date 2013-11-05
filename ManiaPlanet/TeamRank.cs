using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class TeamRank
    {
        public int teamId { get; set; }
        public Team team { get; set; }
        public int zoneId { get; set; }
        public int rank { get; set; }
        public int ladderPoints { get; set; }
        public int titleId { get; set; }
        public string path { get; set; }
    }
}
