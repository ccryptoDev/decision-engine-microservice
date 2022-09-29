using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
  
    [Table("tbl_term")]
    public class Term
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("term_description")]
        public string description { get; set; }
       
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }

    public class TermDtl
    {
       
        public long Id { get; set; }
        public long SettingId { get; set; }

        public string description { get; set; }

       
    }
}
