using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
    public class GradeAPRDTO
    {
        public long Id { get; set; }

        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public char GradeValue { get; set; }
        public double Apr { get; set; }
    }
    public class CreateGradeRequestDTO
    {
        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public char GradeValue { get; set; }
        public double Apr { get; set; }
    }
    public class UpdateGradeRequestDTO
    {
        public long id { get; set; }
        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public char GradeValue { get; set; }
        public double Apr { get; set; }
    }
}
