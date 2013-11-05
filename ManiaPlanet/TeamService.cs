using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public class TeamService : Client
    {
        public TeamService(string username = "", string password = "")
            : base(username, password)
        {

        }

        public Task<Team> GetTeam(int id)
        {
            return Execute<Team>("GET", string.Format("/teams/{0}/", id));
        }

        public Task<List<Contract>> GetContracts(int id)
        {
            return Execute<List<Contract>>("GET", string.Format("/teams/{0}/contracts/", id));
        }

        public Task<List<Player>> GetAdmins(int id)
        {
            return Execute<List<Player>>("GET", string.Format("/teams/{0}/admins/", id));
        }

        public Task<List<TeamRank>> GetRank(int id)
        {
            return Execute<List<TeamRank>>("GET", string.Format("/teams/{0}/rank/", id));
        }
    }
}
