using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
   
    [Table("tbl_term_grade")]
    public class TermGrade
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("term_id")]
        public long TermId { get; set; }
        [Column("grade_id")]
        public long GradeId { get; set; }

        [Column("term_duration")]
        public int TermDuration { get; set; }
        [Column("avg_term_payment")]
        public double AvgTermPayment { get; set; }

        [Column("max_term_payment")]
        public double MaxTermPayment { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }
    public class TermGradeDetail
    {

        public long Id { get; set; }


        public long term_id { get; set; }

        public long grade_id { get; set; }

        public string TermDesc { get; set; }
       
        public string GradeDesc { get; set; }


        public int TermDuration { get; set; }

        public double MaxTermPayment { get; set; }

        public long SettingId { get; set; }
        public double AvgTermPayment { get; set; }

    }
}
