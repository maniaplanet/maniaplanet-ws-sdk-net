using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class Map
	{
		public string id { get; set; }
		public string name { get; set; }
		public string creator { get; set; }
		public string titleId { get; set; }
		public Title title { get; set; }
		public string versionCount { get; set; }
		public string usageCount { get; set; }
	}
}
