using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class DecisionDTO
    {
       
    }
    public class DecisionEngineRequestDTO
    {
        public bool HardPull { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public AddressDTO Address { get; set; }
        public string SsnNumber { get; set; }
        public double income { get; set; }

    }
}
