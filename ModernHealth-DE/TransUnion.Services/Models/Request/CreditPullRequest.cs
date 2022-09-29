using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Services.Models.Request
{
    public class CreditPullRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string StreetAddress { get; set; }
        public string UnitNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
