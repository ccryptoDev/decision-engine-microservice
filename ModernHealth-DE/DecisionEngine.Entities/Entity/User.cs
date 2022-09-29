using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
   public class WelcomeTechUser
    {
        public Guid userID { get; set; }
    }
    public class RulePoder
    {
        public List<PrRules> rules { get; set; }
    }
    public class PrRules
    {
        public string rule { get; set; }
        public string ruleDescription { get; set; }
        public string result { get; set; }
    }
    [Table("tbluser")]
    public class User
    {
        [Column("id")]
        public Guid userID { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    [Table("tblcustomer")]
    public class Customer
    {
        [Key]
        public int ref_no { get; set; }
        public Guid user_id { get; set; }
        public string socialSecurityNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}
