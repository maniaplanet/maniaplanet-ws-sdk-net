﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class ZoneRanking
	{
		public int idZone { get; set; }
		public string path { get; set; }
		public string environment { get; set; }
		public string unit { get; set; }
		public List<PlayerRank> players { get; set; }
	}
}
