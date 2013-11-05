using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class Server
    {
        public int id { get; set; }
        public string login { get; set; }
        public string owner { get; set; }
        public string serverName { get; set; }
        public string description { get; set; }
        public int isOnline { get; set; }
        public int isDedicated { get; set; }
        public string[] mapsList { get; set; }
        public int idZone { get; set; }
        public int playerCount { get; set; }
        public int maxPlayerCount { get; set; }
        public string titleId { get; set; }
        public string isPrivate { get; set; }
        public string scriptName { get; set; }
        public string scriptVersion { get; set; }
        public string scriptTeam { get; set; }
        public int isLadder { get; set; }
        public int isLobby { get; set; }
        public double? ladderLimitMax { get; set; }
        public double? ladderLimitMin { get; set; }
        public object adequacy { get; set; }
        public string buildVersion { get; set; }
        public string broadcasters { get; set; }
        public string relayOf { get; set; }
        public double ladderPointsAvg { get; set; }
        public double ladderPointsMin { get; set; }
        public double ladderPointsMax { get; set; }
        public Zone zone { get; set; }
        public Title title { get; set; }
    }
}
