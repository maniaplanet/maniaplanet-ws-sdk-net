using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaHome
{
    public class ServerPublisher : Client
    {
        protected string _serverLogin;

        public ServerPublisher(string username, string password, string serverLogin = null)
            : base(username, password)
        {
            _serverLogin = serverLogin;
        }

        /// <summary>
        /// Send a public notification to every player that bookmarked your Manialink.
        /// </summary>
        /// <param name="message">The message itself</param>
        /// <param name="link">Link when the player clicks on the notification</param>
        /// <param name="iconStyle">Icon style (from the Manialink styles)</param>
        /// <param name="iconSubStyle">Icon substyle (from the Manialink styles)</param>
        /// <param name="titleIdString">the titleIdString where the notification will be visible. Leave empty to post for ManiaPlanet</param>
        /// <param name="mediaURL">Link to a picture (jpg,png or dds) or a video (bik)</param>
        /// <returns></returns>
        public Task<int> PostPublicNotification(string message, string link = null, string iconStyle = null, string iconSubStyle = null, string titleIdString = null, string mediaURL = null)
        {
            Notification n = new Notification();
            n.senderName = new { serverLogin = _serverLogin };
            n.message = message;
            n.link = link;
            n.iconStyle = iconStyle;
            n.iconSubStyle = iconSubStyle;
            n.titleId = titleIdString;
            n.mediaURL = mediaURL;
            return Execute<int>("POST", "/maniahome/notification/public/", n);
        }

        /// <summary>
        /// Send a public notification to a player specified by receiverName.
        /// The message will be prepended with its nickname and will be visible by all its buddies.
        /// </summary>
        /// <param name="message">The message itself</param>
        /// <param name="receiverName">The receiver of the notification</param>
        /// <param name="link">Link when the player clicks on the notification</param>
        /// <param name="iconStyle">Icon style (from the Manialink styles)</param>
        /// <param name="iconSubStyle">Icon substyle (from the Manialink styles)</param>
        /// <param name="titleIdString">the titleIdString where the notification will be visible. Leave empty to post for ManiaPlanet</param>
        /// <param name="mediaURL">Link to a picture (jpg,png or dds) or a video (bik)</param>
        /// <returns></returns>
        public Task<int> PostPersonalNotification(string message, string receiverName, string link = null, string iconStyle = null, string iconSubStyle = null, string titleIdString = null, string mediaURL = null)
        {
            Notification n = new Notification();
            n.senderName = new { serverLogin = _serverLogin };
            n.receiverName = receiverName;
            n.message = message;
            n.link = link;
            n.iconStyle = iconStyle;
            n.iconSubStyle = iconSubStyle;
            n.titleId = titleIdString;
            n.mediaURL = mediaURL;
            return Execute<int>("POST", "/maniahome/notification/personal/", n);
        }

        /// <summary>
        /// Send a private message to a player specified by receiverName.
        /// </summary>
        /// <param name="message">The message itself</param>
        /// <param name="receiverName">The receiver of the notification</param>
        /// <param name="link">Link when the player clicks on the notification</param>
        /// <param name="titleIdString">the titleIdString where the notification will be visible. Leave empty to post for ManiaPlanet</param>
        /// <returns></returns>
        public Task<int> PostPrivateNotification(string message, string receiverName, string link = null, string titleIdString = null)
        {
            Notification n = new Notification();
            n.senderName = new { serverLogin = _serverLogin };
            n.message = message;
            n.link = link;
            n.receiverName = receiverName;
            n.isPrivate = true;
            n.titleId = titleIdString;
            return Execute<int>("POST", "/maniahome/notification/private/", n);
        }
    }
}
