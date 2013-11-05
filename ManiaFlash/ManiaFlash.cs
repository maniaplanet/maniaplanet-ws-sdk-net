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

        public Task<Channel> GetChannel(int id)
        {
            return Execute<Channel>("GET", string.Format("/maniaflash/channels/{0}/", id));
        }

        public Task<List<Message>> GetMessages(int id, int offset = 0, int length = 0)
        {
            string query = string.Empty;

            return Execute<List<Message>>("GET", string.Format("/maniaflash/channels/{0}/messages/?offset={1}&length={2}", id, offset, length));
        }
        //postMessage($channelId, $message, $link = null, $iconStyle = null, $iconSubStyle = null, $mediaURL = null)

        public Task<bool> PostMessage(string channelId, Message message)
        {
            return Execute<bool>("POST", string.Format("/maniaflash/channels/{0}/", channelId), message);
        }
    }
}
