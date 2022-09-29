using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rules_Engine.Entities.Entity
{
   
        [Table("tblrules")]
        public class Rule
        {
            [Key]
            [Column("id")]
            public long Id { get; set; }
            [Column("rule_id")]
            public long? rule_id { get; set; }

            // public string? description { get; set; }
            [Column("declinedif")]
            public string? declinedif { get; set; }

            public double value { get; set; }

            public Boolean disabled { get; set; }

            [Column("createdat")]
            public DateTime createdAt { get; set; }

        }

    public class RulesResponse
    {
        public long id { get; set; }
        public long? rule_id { get; set; }
        public string? description { get; set; }
        public string? declinedif { get; set; }
        public float value { get; set; }

        public Boolean disabled { get; set; }



    }

}
