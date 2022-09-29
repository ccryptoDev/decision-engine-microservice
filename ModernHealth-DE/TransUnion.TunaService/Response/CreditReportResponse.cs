using System;
using System.Xml.Serialization;
using DecisionEngine.TunaService.Response.Model;

namespace DecisionEngine.TunaService.Response
{
    [Serializable]
    [XmlRoot(Namespace = "http://www.transunion.com/namespace", ElementName = "creditBureau", DataType = "string", IsNullable = true)]
    public class CreditReportResponse : ResponseBase
    {
        public Product product { get; set; }
    }

    public class Contansts
    {

        public class ECOADesignator
        {
            public const string Individual = "individual";
            public const string AuthorizedUser = "authorizedUser";
            public const string JointContractLiability = "jointContractLiability";
            public const string Participant = "participant";
        }

    }
}
