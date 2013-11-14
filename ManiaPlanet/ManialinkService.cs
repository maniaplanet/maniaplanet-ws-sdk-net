using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class ManialinkService : Client
	{
		public ManialinkService(string username, string password)
			: base(username, password)
		{

		}

		public Task<Manialink> GetDetails(string code)
		{
			string encodedCode = System.Net.HttpUtility.UrlEncode(code);
			return Execute<Manialink>("GET", string.Format("/manialinks/{0}/", encodedCode));
		}
	}
}
