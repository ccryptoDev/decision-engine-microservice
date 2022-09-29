using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rules_Engine.Entities.Entity
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
      
        [Column("grade")]
        public char GradeValue { get; set; }
        [Column("apr")]
        public double Apr { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }

        public Boolean active { get; set; }
    }

    public class CreateGradeRequest
    {
        public long FromScore { get; set; }

        public long ToScore { get; set; }
    }
    public class UpdateGradeRequest
    {
        public long id { get; set; }
        public long FromScore { get; set; }

        public long ToScore { get; set; }
    }
}
