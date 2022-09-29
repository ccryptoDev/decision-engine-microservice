using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisionEngine.DataService.Data.Entities
{
    [Table("tbl_score")]
    public class Score
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("from_score")]
        public int FromScore { get; set; }

        [Column("to_score")]
        public int ToScore { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}