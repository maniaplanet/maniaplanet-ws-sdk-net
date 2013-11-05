using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class CompetitionService : Client
    {
        public CompetitionService(string username = "", string password = "")
            : base(username, password)
        {

        }

        public Task<List<MapVersion>> GetMapPool(int competitionId)
        {
            return Execute<List<MapVersion>>("GET", string.Format("/competitions/{0}/maps/", competitionId));
        }

        public Task<List<string>> GetInvitationKey(int competitionId)
        {
            return Execute<List<string>>("GET", string.Format("/competitions/{0}/keys/", competitionId));
        }

        public Task<int> InviteTeam(int competitionId, int teamId)
        {
            return Execute<int>("POST", string.Format("/competitions/{0}/invite/", competitionId), new { teamId = teamId });
        }

        public Task<object> RemoveTeam(int competitionId, int teamId)
        {
            return Execute<object>("DELETE", string.Format("/competitions/{0}/teams/{1}/", competitionId, teamId));
        }
    }
}
