using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisionEngine.DataService.Data.Entities
{
    [Table("tbl_income")]
    public class Income
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("min_income")]
        public double MinIncome { get; set; }

        [Column("max_income")]
        public double MaxIncome { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
