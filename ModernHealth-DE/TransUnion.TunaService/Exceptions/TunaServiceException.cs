using System;
using System.Net;

namespace DecisionEngine.TunaService
{
    public class TunaServiceException : Exception
    {
        public TunaServiceException(HttpStatusCode statusCode, string reasonPhrase, string message, TunaServiceError error)
            : base(message)
        {
            this.StatusCode = statusCode;
            this.ReasonPhrase = reasonPhrase;
            this.ServiceErrorResponse = error;
        }
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }

        public TunaServiceError ServiceErrorResponse { get; set; }
    }

}
