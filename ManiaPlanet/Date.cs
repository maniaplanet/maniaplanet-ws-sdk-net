using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
	public class Date
	{
		public string date { get; set; }
		public int timezone_type { get; set; }
		public string timezone { get; set; }
		protected DateTime _systemObject;

		public DateTime systemObject
		{
			get
			{
				if (_systemObject == default(DateTime))
				{
					_systemObject = DateTime.ParseExact(date,"yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
				}
				return _systemObject;
			}
		}
	}
}
