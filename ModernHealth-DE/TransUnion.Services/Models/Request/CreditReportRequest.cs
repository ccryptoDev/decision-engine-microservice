using System;
using System.Collections.Generic;

namespace DecisionEngine.Services.Models.Request
{
    public class CreditReportRequest
    {
        public bool HardPull { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public Address Address { get; set; }
        public string SsnNumber { get; set; }
        public long loanAmount { get; set; }
        public long settingId { get; set; }
        public List<BankRule> bankRules { get; set; }
    }
   
}
