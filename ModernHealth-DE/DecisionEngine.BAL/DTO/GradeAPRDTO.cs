using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class GradeAPRDTO
    {
        public long Id { get; set; }

        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public long GradeId { get; set; }
        public double Apr { get; set; }
        public long SettingId { get; set; }
    }
    public class CreateGradeRequestDTO
    {
        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public long GradeId { get; set; }
        public double Apr { get; set; }
        public long SettingId { get; set; }
    }
    public class UpdateGradeRequestDTO
    {
        public long id { get; set; }
        public long ScoreId { get; set; }

        public long IncomeId { get; set; }
        public long GradeId { get; set; }
        public double Apr { get; set; }
        public long SettingId { get; set; }
    }
    public class GradeAPRDetailDTO
    {

        public long Id { get; set; }

        public long ScoreId { get; set; }

        public long IncomeId { get; set; }


        public long GradeId { get; set; }

        public double Apr { get; set; }
        //  public string Score { get; set; }

        //  public string Income { get; set; }

        public long SettingId { get; set; }
        public string GradeValue { get; set; }
    }
}
