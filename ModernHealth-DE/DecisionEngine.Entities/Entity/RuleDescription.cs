using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
    [Table("tblrules_description")]
    public class RuleDescription
    {

        [Key]
        [Column("id")]
        public long Id { get; set; }

        public string description { get; set; }

        [Column("short_desc")]
        public string short_desc { get; set; }

        public Boolean active { get; set; }

    }
}
