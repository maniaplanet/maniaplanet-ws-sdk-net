using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class ZoneService : Client
	{
		public ZoneService(string username = "", string password = "")
			: base(username, password)
		{

		}

		public Task<Zone> Get(int id)
		{
			return Execute<Zone>("GET", string.Format("/zones/id/{0}/", id));
		}

		public Task<Zone> GetByPath(string path)
		{
			string encodedPath = System.Net.HttpUtility.UrlEncode(path);
			return Execute<Zone>("GET", string.Format("/zones/path/{0}/", encodedPath));
		}

		public Task<List<Zone>> GetAll(int offset = 0, int length = 10, string sort = "", int order = 1)
		{
			string encodedSort = System.Net.HttpUtility.UrlEncode(sort);
			return Execute<List<Zone>>("GET", string.Format("/zones/all/?offset={0}&length={1}&sort={2}&order={3}", offset, length, encodedSort, order));
		}

		public Task<List<Zone>> GetChildren(int id, int offset = 0, int length = 10, string sort = "", int order = 1)
		{
			string encodedSort = System.Net.HttpUtility.UrlEncode(sort);
			return Execute<List<Zone>>("GET", string.Format("/zones/id/{0}/children/?offset={1}&length={2}&sort={3}&order={4}", id, offset, length, encodedSort, order));
		}

		public Task<List<Zone>> GetChildrenByPath(string path, int offset = 0, int length = 10, string sort = "", int order = 1)
		{
			string encodedPath = System.Net.HttpUtility.UrlEncode(path);
			string encodedSort = System.Net.HttpUtility.UrlEncode(sort);
			return Execute<List<Zone>>("GET", string.Format("/zones/path/{0}/children/?offset={1}&length={2}&sort={3}&order={4}", encodedPath, offset, length, encodedSort, order));
		}

		public Task<int> GetId(string path)
		{
			string encodedPath = System.Net.HttpUtility.UrlEncode(path);
			return Execute<int>("GET", string.Format("/zones/path/{0}/id/", path));
		}

		public Task<int> GetPopulation(int id)
		{
			return Execute<int>("GET", string.Format("/zones/id/{0}/population/", id));
		}
	}
}
