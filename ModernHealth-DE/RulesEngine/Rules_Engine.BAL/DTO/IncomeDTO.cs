using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
   public class IncomeDTO
    {
        public long Id { get; set; }

    
        public double MinIncome { get; set; }
      

        public double MaxIncome { get; set; }
    }
    public class CreateIncomeRequestDTO
    {
        public double MinIncome { get; set; }

        public double MaxIncome { get; set; }
    }
    public class UpdateIncomeRequestDTO
    {
        public long id { get; set; }
        public double MinIncome { get; set; }

        public double MaxIncome { get; set; }
    }
}
