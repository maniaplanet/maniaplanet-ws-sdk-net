using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class TitleService : Client
	{
		public TitleService(string username = "", string password = "")
			: base(username, password)
		{

		}

		public Task<Title> GetDetails(string idString)
		{
			string encodedTitle = HttpUtility.UrlEncode(idString);
			return Execute<Title>("GET", string.Format("/titles/{0}/", encodedTitle));
		}
	}
}
