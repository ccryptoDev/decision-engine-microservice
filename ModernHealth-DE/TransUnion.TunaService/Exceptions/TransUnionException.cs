using System;
using System.Net;

namespace DecisionEngine.TunaService
{
    public class TransUnionException : Exception
    {
        public TransUnionException(HttpStatusCode statusCode, string reasonPhrase, string errorCode, string message) : base($"{statusCode} - {message}")
        {
            this.StatusCode = statusCode;
            this.ReasonPhrase = reasonPhrase;
        }

        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }

        public string ErrorCode { get; set; }
    }
}
