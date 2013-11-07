using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet.ManiaConnect
{
    public class PlayerService : OauthClient
    {
        protected object _result;

        public PlayerService(string username = "", string password = "")
            : base(username, password)
        {

        }

        /// <summary>
        /// This is the first method to call when you have an authorization code.
        /// It will retrieve an access token if possible and then call the service to
        /// retrieve a basic object about the authentified player.
        /// 
        /// You do not need any special scope to call this service, as long as you have an access token.
        /// 
        /// If an access token is not found, it will return false
        /// </summary>
        /// <returns>A player object or null if no access token is found</returns>
        public async Task<Player> GetPlayer()
        {
            if (_persistance != null)
            {
                var cachePlayer = _persistance.GetVariable<Player>("player");
                if (cachePlayer != null)
                {
                    return cachePlayer;
                }
            }
            await GetAccessToken();
            if (_token != null)
            {
                return await ExecuteOAuth2<Player>("GET", "/player/");
            }
            return null;
        }

        /// <summary>
        /// Returns an object containing the online status and the dedicated server
        /// info on which the player is playing, if applicable.
        /// 
        /// Scope needed: online_status
        /// </summary>
        /// <returns></returns>
        public Task<PlayerOnlineStatus> GetOnlineStatus()
        {
            return ExecuteOAuth2<PlayerOnlineStatus>("GET", "/player/status/");
        }

        /// <summary>
        /// Returns the email associated with the player's account.
        /// 
        /// Scope needed: email
        /// </summary>
        /// <returns></returns>
        public Task<string> GetEmail()
        {
            return ExecuteOAuth2<string>("GET", "/player/email/");
        }

        /// <summary>
        /// Returns the buddies of the player as an array of player objects
        /// 
        /// Scope needed: buddies
        /// </summary>
        /// <returns></returns>
        public Task<List<Player>> GetBuddies()
        {
            return ExecuteOAuth2<List<Player>>("GET", "/player/buddies/");
        }

        /// <summary>
        /// Gets the list of the player's registered dedicated servers and their online statuses.
        /// 
        /// Scope needed: dedicated
        /// </summary>
        /// <returns></returns>
        public Task<List<Server>> GetDedicated()
        {
            return ExecuteOAuth2<List<Server>>("GET", "/player/dedicated/");
        }

        /// <summary>
        /// Gets the list of the player's registered Manialinks.
        /// 
        /// Scope needed: manialinks
        /// </summary>
        /// <returns></returns>
        public Task<List<string>[]> GetManialinks()
        {
            return ExecuteOAuth2<List<string>[]>("GET", "/player/manialinks/");
        }

        /// <summary>
        /// Get the player's list of contracts team
        /// 
        /// scope needed : teams
        /// </summary>
        /// <returns></returns>
        public Task<List<Contract>> GetContracts()
        {
            return ExecuteOAuth2<List<Contract>>("GET", "/player/contracts/");
        }

        /// <summary>
        /// Get team's whose player is admin
        /// 
        /// scope needed : teams
        /// </summary>
        /// <returns></returns>
        public Task<List<Team>> GetTeams()
        {
            return ExecuteOAuth2<List<Team>>("GET", "/player/teams/");
        }

        /// <summary>
        /// Get the player's list of owned titles
        /// 
        /// scope needed : titles
        /// </summary>
        /// <returns></returns>
        public Task<List<Title>> GetOwnedTitles()
        {
            return ExecuteOAuth2<List<Title>>("GET", "/player/titles/owned/");
        }

        /// <summary>
        /// Get the player's list of installed titles
        /// 
        /// scope needed : titles
        /// </summary>
        /// <returns></returns>
        public Task<List<Title>> GetInstalledTitles()
        {
            return ExecuteOAuth2<List<Title>>("GET", "/player/titles/installed/");
        }

        /// <summary>
        /// Get the player's list of favorite servers
        /// 
        /// scope needed : favorite_servers
        /// </summary>
        /// <returns></returns>
        public Task<List<Server>> GetFavoriteServers()
        {
            return ExecuteOAuth2<List<Server>>("GET", "/favorites/servers/");
        }
    }
}
