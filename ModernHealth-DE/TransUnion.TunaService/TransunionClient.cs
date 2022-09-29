using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DecisionEngine.TunaService
{
    public class TransUnionClient : ITransUnionClient
    {
        private readonly HttpClient httpClient;

        public TransUnionClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public RawXmlHandler RequestXmlHandler { get; set; }
        public RawXmlHandler ResponseXmlHandler { get; set; }

        public async Task<TOutput> ExecuteAsync<TInput, TOutput>(TInput request)
            where TInput : Request.RequestBase
            where TOutput : Response.ResponseBase
        {
            string xmlRequest = this.Parse<TInput>(request);

            if (RequestXmlHandler != null)
                RequestXmlHandler.Invoke(xmlRequest);

            var response = await httpClient.PostAsync("", new StringContent(xmlRequest, Encoding.UTF8, "application/xml"));
            if (response.IsSuccessStatusCode)
            {
                string xmlResponse = await response.Content.ReadAsStringAsync();

                if (ResponseXmlHandler != null)
                    ResponseXmlHandler.Invoke(xmlResponse);

                return this.Parse<TOutput>(xmlResponse);
            }
            else
            {
                string errMsg = await response.Content.ReadAsStringAsync();
                var err = this.ParseError<TunaServiceError>(errMsg);
                if (err != null)
                    err.ErrorCode = err.ErrorCode?.Replace("\n", string.Empty);

                throw new TunaServiceException(response.StatusCode, response.ReasonPhrase, err.ErrorText, err);
            }
        }

        private string Parse<T>(T input) where T : Request.RequestBase
        {
            var xml = string.Empty;

            XmlSerializer xsserializer = new XmlSerializer(typeof(T));
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsserializer.Serialize(writer, input);
                    xml = sww.ToString(); // Your XML
                }
            }
            return xml;
        }

        private T Parse<T>(string xml) where T : Response.ResponseBase
        {
            XmlSerializer xsserializer = new XmlSerializer(typeof(T));
            return (T)xsserializer.Deserialize(new StringReader(xml));
        }

        private T ParseError<T>(string xml)
        {
            XmlSerializer xsserializer = new XmlSerializer(typeof(T));
            return (T)xsserializer.Deserialize(new StringReader(xml));
        }
    }
}
