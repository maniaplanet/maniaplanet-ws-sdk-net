using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaHome
{
	class Notification
	{
		public object senderName { get; set; }
		public string receiverName { get; set; }
		public string message { get; set; }
		public string link { get; set; }
		public bool isPrivate { get; set; }
		public string iconStyle { get; set; }
		public string iconSubStyle { get; set; }
		public string group { get; set; }
		public int priority { get; set; }
		public string titleId { get; set; }
		public string mediaURL { get; set; }
	}
}
