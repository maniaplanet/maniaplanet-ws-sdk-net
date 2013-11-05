using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK.ManiaFlash
{
    public class Message
    {
        public int id { get; set; }
        public string author { get; set; }
        public string dateCreated { get; set; }
        public string message { get; set; }
        public string link { get; set; }
        public string iconStyle { get; set; }
        public string iconSubStyle { get; set; }
        public object mediaURL { get; set; }
    }
}
