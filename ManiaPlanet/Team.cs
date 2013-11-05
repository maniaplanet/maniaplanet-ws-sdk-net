using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class Team
    {
        public int id { get; set; }
        public string creatorLogin { get; set; }
        public string tag { get; set; }
        public int level { get; set; }
        public string name { get; set; }
        public string primaryColor { get; set; }
        public string secondaryColor { get; set; }
        public string description { get; set; }
        public string emblem { get; set; }
        public string emblemWeb { get; set; }
        public string logo { get; set; }
        public Date creationDate { get; set; }
        public string city { get; set; }
        public int zoneId { get; set; }
        public Zone zone { get; set; }
        public int titleId { get; set; }
        public Title title { get; set; }
        public object rank { get; set; }
        public string score { get; set; }
        public int points { get; set; }
        public int ladderPoints { get; set; }
        public int teamSize { get; set; }
        public int maxTeamSize { get; set; }
        public int minTeamSize { get; set; }
        public int deleted { get; set; }
    }
}
