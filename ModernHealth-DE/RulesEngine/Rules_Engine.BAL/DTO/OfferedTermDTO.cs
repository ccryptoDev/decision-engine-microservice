using System;
using System.Collections.Generic;
using System.Text;


namespace Rules_Engine.BAL.DTO
{
    public class OfferedTermDTO
    {
        public long Id { get; set; }

        public string TermName { get; set; }

        public int TermValue { get; set; }
        public double AvgMonthlyPayment { get; set; }
        public double MaxMonthlyPayment { get; set; }
        public int LoanOfferId { get; set; }
    }
    public class CreateOfferedTermRequestDTO
    {
        public string TermName { get; set; }
        public int TermValue { get; set; }
        public double AvgMonthlyPayment { get; set; }
        public double MaxMonthlyPayment { get; set; }
        public int LoanOfferId { get; set; }
    }
    public class UpdateOfferedTermRequestDTO
    {
        public long Id { get; set; }

        public string TermName { get; set; }

        public int TermValue { get; set; }
        public double AvgMonthlyPayment { get; set; }
        public double MaxMonthlyPayment { get; set; }
        public int LoanOfferId { get; set; }
    }
}
