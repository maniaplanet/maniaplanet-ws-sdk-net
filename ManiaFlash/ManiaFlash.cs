using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaFlash
{
	public class ManiaFlash : Client
	{
		public ManiaFlash(string username = "", string password = "")
			: base(username, password)
		{

		}

		/// <summary>
		/// Get channel information
		/// </summary>
		/// <param name="id">the channel id you want to get</param>
		/// <returns></returns>
		public Task<Channel> GetChannel(int id)
		{
			return Execute<Channel>("GET", string.Format("/maniaflash/channels/{0}/", id));
		}

		/// <summary>
		/// Get messages from a channel
		/// </summary>
		/// <param name="id">channel id</param>
		/// <param name="offset">from which message you want to start</param>
		/// <param name="length">represent the number of message you will get</param>
		/// <returns></returns>
		public Task<List<Message>> GetMessages(int id, int offset = 0, int length = 0)
		{
			string query = string.Empty;

			return Execute<List<Message>>("GET", string.Format("/maniaflash/channels/{0}/messages/?offset={1}&length={2}", id, offset, length));
		}

		/// <summary>
		/// Post a message on a channel
		/// </summary>
		/// <param name="channelId">the Id string of the channel</param>
		/// <param name="message">The message itself</param>
		/// <returns></returns>
		public Task<bool> PostMessage(string channelId, Message message)
		{
			return Execute<bool>("POST", string.Format("/maniaflash/channels/{0}/", channelId), message);
		}
	}
}
