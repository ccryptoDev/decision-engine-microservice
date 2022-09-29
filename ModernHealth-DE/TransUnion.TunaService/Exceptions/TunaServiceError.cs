using System.Xml.Serialization;

namespace DecisionEngine.TunaService
{
    [XmlRoot("error")]
    public class TunaServiceError
    {
        [XmlElement("errorcode")]
        public string ErrorCode { get; set; }

        [XmlElement("errortext")]
        public string ErrorText { get; set; }

        public string ErrorMessage
        {
            get
            {
                return $"{ErrorCode} - {ErrorText}";
            }
        }
    }
}
