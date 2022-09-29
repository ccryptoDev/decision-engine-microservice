using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
    [Table("tbl_gradeapr")]
    public class GradeAPR
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("score_id")]
        public long ScoreId { get; set; }

        // public string? description { get; set; }
        [Column("income_id")]
        public long IncomeId { get; set; }
      
        [Column("grade_id")]
        public long GradeId { get; set; }
        [Column("apr")]
        public double Apr { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
        public Boolean active { get; set; }
    }
    public class GradeAPRDetail
    {
       
        public long Id { get; set; }
      
        public long ScoreId { get; set; }

        public long IncomeId { get; set; }

       
        public long GradeId { get; set; }
       
        public double Apr { get; set; }
        public string Score { get; set; }

        public string Income { get; set; }
        public long SettingId { get; set; }

        public string GradeValue { get; set; }
    }
}
