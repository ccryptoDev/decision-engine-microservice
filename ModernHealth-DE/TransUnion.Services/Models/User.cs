using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DecisionEngine.Services.Models
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MIddleName { get; set; }

        
        [Required]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Street { get; set; }
       
        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string SsnNumber { get; set; }
    }
}
