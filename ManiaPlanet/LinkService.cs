using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaPlanet
{
    public enum LinkType
    {
        CATEGORY_URL = 1,
        CATEGORY_SOCIAL = 2,
        CATEGORY_MANIALINK = 3,
        CATEGORY_EMAIL = 4,
        CATEGORY_IRC = 5,
        CATEGORY_VOD = 6,
        CATEGORY_STREAM = 7,
        CATEGORY_SERVER_LOGIN = 8,
        CATEGORY_REGISTRATION = 9,
        CATEGORY_MANIALINK_BRACKETS = 10,
        CATEGORY_URL_BRACKETS = 11
    }

    public class LinkService : Client
    {
        const int CATEGORY_URL = 1;
        const int CATEGORY_SOCIAL = 2;
        const int CATEGORY_MANIALINK = 3;
        const int CATEGORY_EMAIL = 4;
        const int CATEGORY_IRC = 5;
        const int CATEGORY_VOD = 6;
        const int CATEGORY_STREAM = 7;
        const int CATEGORY_SERVER_LOGIN = 8;
        const int CATEGORY_REGISTRATION = 9;
        const int CATEGORY_MANIALINK_BRACKETS = 10;
        const int CATEGORY_URL_BRACKETS = 11;

        public LinkService(string username = "", string password = "")
            : base(username, password)
        {

        }

        public Task<bool> CreateForTeam(int teamId, string link, string name, LinkType category, bool isFeatured = false)
        {
            var obj = new
            {
                link = link,
                name = name,
                category = category,
                featured = isFeatured,
                teamId = teamId
            };
            return Execute<bool>("POST", string.Format("/teams/{0}/links/", teamId), obj);
        }

        public Task<bool> CreateForCompetition(int competitionId, string link, string name, LinkType category, bool isFeatured = false)
        {
            var obj = new
            {
                link = link,
                name = name,
                category = category,
                featured = isFeatured,
                competitionId = competitionId
            };
            return Execute<bool>("POST", string.Format("/competitions/{0}/links/", competitionId), obj);
        }
    }
}
