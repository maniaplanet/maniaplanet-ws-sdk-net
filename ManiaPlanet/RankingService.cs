using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class RankingService : Client
    {
        public RankingService(string username = "", string password = "")
            : base(username, password)
        {

        }

        public Task<Ranking> GetMultiplayerPlayer(string titleId, string login)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedLogin = HttpUtility.UrlEncode(login);
            return Execute<Ranking>("GET", this.GetPrefixEndpoint(titleId) + string.Format("/rankings/multiplayer/player/{0}/?title={1}", encodedLogin, encodedTitleId));
        }

        public Task<ZoneRanking> GetMultiplayerWorld(string titleId, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            return Execute<ZoneRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/multiplayer/zone/?offset={0}&length={1}&title={2}", offset, length, encodedTitleId));
        }

        public Task<ZoneRanking> GetMultiplayerZones(string titleId, string path, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedPath = System.Net.HttpUtility.UrlEncode(titleId);
            return Execute<ZoneRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/multiplayer/zone/{0}/?title={1}&offset={2}&length={3}", encodedPath, encodedTitleId, offset, length));
        }

        public Task<Ranking> GetSoloPlayer(string titleId, string login)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedLogin = HttpUtility.UrlEncode(login);
            return Execute<Ranking>("GET", this.GetPrefixEndpoint(titleId) + string.Format("/rankings/solo/player/{0}/?title={1}", encodedLogin, encodedTitleId));
        }

        public Task<ZoneRanking> GetSoloWorld(string titleId, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            return Execute<ZoneRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/solo/zone/?offset={0}&length={1}&title={2}", offset, length, encodedTitleId));
        }

        public Task<ZoneRanking> GetSoloZones(string titleId, string path, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedPath = System.Net.HttpUtility.UrlEncode(titleId);
            return Execute<ZoneRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/solo/zone/{0}/?title={1}&offset={2}&length={3}", encodedPath, encodedTitleId, offset, length));
        }

        public Task<ChallengeRanking> GetSoloChallengeWorld(string titleId, string challengeuid, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedChallengeUid = HttpUtility.UrlEncode(challengeuid);
            return Execute<ChallengeRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/solo/challenge/{0}/?offset={1}&length={2}&title={3}", encodedChallengeUid, offset, length, encodedTitleId));
        }

        public Task<ChallengeRanking> GetSoloChallengeZone(string titleId, string challengeuid, string path, int offset = 0, int length = 100)
        {
            string encodedTitleId = System.Net.HttpUtility.UrlEncode(titleId);
            string encodedPath = System.Net.HttpUtility.UrlEncode(path);
            string encodedChallengeUid = HttpUtility.UrlEncode(challengeuid);
            return Execute<ChallengeRanking>("GET", this.GetPrefixEndpoint(titleId) + 
                string.Format("/rankings/solo/challenge/{0}/{1}/?offset={2}&length={3}&title={4}", challengeuid, encodedPath, offset, length, encodedTitleId));
        }

        protected string GetPrefixEndpoint(string titleId)
        {
            switch (titleId)
            {
                case "SMStorm":
                    return "/storm";

                case "TMCanyon":
                    return "/canyon";

                case "SMStormRoyal@nadeolabs":
                    return "/royal";

                case "TMStadium":
                    return "/stadium";

                case "SMStormElite@nadeolabs":
                    return "/elite";

                case "TMValley":
                    return "/valley";

                default:
                    return "/titles";
            }
        }
    }
}
