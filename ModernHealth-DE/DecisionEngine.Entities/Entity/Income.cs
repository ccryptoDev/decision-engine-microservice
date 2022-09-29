using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
    [Table("tbl_income")]
    public  class Income
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
      
        [Column("min_income")]
        public double MinIncome { get; set; }
        [Column("max_income")]
        public double MaxIncome { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }
   
}
