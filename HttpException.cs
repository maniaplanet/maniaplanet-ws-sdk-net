using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManiaPlanetWSSDK
{
    public class HttpException : Exception
    {
        protected HttpStatusCode HTTPStatusCode;

        public HttpException(string message, HttpStatusCode code) 
            : base(message)
        {
            HTTPStatusCode = code;
        }

        public HttpException(string message, HttpStatusCode code, Exception innerException)
            : base(message, innerException)
        {
            HTTPStatusCode = code;
        }

        public HttpStatusCode StatusCode { get { return HTTPStatusCode; } }
    }
}
