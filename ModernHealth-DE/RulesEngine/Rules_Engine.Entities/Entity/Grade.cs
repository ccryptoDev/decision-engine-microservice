using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rules_Engine.Entities.Entity
{
   
        [Table("tbl_grade")]
        public class Grade
        {
            [Key]
            [Column("id")]
            public long Id { get; set; }
            [Column("from_score")]
            public long FromScore { get; set; }

            // public string? description { get; set; }
            [Column("to_score")]
            public long ToScore { get; set; }
            [Column("min_income")]
            public double MinIncome { get; set; }
            [Column("max_income")]
            public double MaxIncome { get; set; }
            [Column("grade")]
            public char GradeValue { get; set; }
            [Column("apr")]
            public double Apr { get; set; }
            [Column("createdat")]
            public DateTime createdAt { get; set; }

            [Column("modifiedat")]
            public DateTime modifiedAt { get; set; }

        public Boolean active { get; set; }

        }

    public class DeleteRequestGrade
    {
        public long Id { get; set; }
    }


}
