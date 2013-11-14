using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class ServerService : Client
	{
		const string ALL_MODES = "-1";
		const string OFFICIAL_MODES = "-2";
		const string CUSTOM_MODES = "-3";

		public ServerService(string username = "", string password = "")
			: base(username, password)
		{

		}

		public Task<Server> GetServer(string login)
		{
			string encodedLogin = HttpUtility.UrlEncode(login);
			return Execute<Server>("GET", string.Format("/servers/{0}/", encodedLogin));
		}

		public Task<List<Player>> GetOnlinePlayers(string login)
		{
			string encodedLogin = HttpUtility.UrlEncode(login);
			return Execute<List<Player>>("GET", string.Format("/servers/{0}/players/", encodedLogin));
		}

		public Task<int> GetFavoritedCount(string login)
		{
			string encodedLogin = HttpUtility.UrlEncode(login);
			return Execute<int>("GET", string.Format("/servers/{0}/favorited/", encodedLogin));
		}

		public Task<List<Server>> GetFilteredList(Dictionary<String, String> filters = null)
		{
			var query = (from i in filters
						 where i.Key == "playerMin" ||
								 i.Key == "playerMax" ||
								 i.Key == "hideFull" ||
								 i.Key == "visibility" ||
								 i.Key == "zone" ||
								 i.Key == "mode" ||
								 i.Key == "ladderLimitMin" ||
								 i.Key == "ladderLimitMax" ||
								 i.Key == "offset" ||
								 i.Key == "length"
						 select string.Format("{0}={1}", HttpUtility.UrlEncode(i.Key), HttpUtility.UrlEncode(i.Value))).ToArray();
			string queryString = "?" + string.Join("&", query);
			return Execute<List<Server>>("GET", string.Format("/servers/{0}", queryString));
		}
	}
}
