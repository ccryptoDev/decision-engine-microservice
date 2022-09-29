using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisionEngine.DataService.Data.Entities
{
    [Table("tbl_gradeapr")]
    public class GradeApr
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("grade")]
        public string Grade { get; set; }

        [Column("apr")]
        public double Apr { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("income_id")]
        public int IncomeId { get; set; }


        [Column("score_id")]
        public int ScoreId { get; set; }

        public Score Score { get; set; }

        public Income Income { get; set; }
    }
}
