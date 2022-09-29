using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class TermGradeDTO
    {
      
        public long Id { get; set; }

       
        public long TermId { get; set; }
    
        public long GradeId { get; set; }

      
        public int TermDuration { get; set; }
      
        public double AvgTermPayment { get; set; }

        public double MaxTermPayment { get; set; }
        public long SettingId { get; set; }


    }
    public class CreateTermGradeRequestDTO
    {

     
        public long TermId { get; set; }

        public long GradeId { get; set; }


        public int TermDuration { get; set; }

        public double AvgTermPayment { get; set; }

        public double MaxTermPayment { get; set; }
        public long SettingId { get; set; }


    }
    public class TermGradeDetailDTO
    {
        public long Id { get; set; }


        public long term_id { get; set; }

        public long grade_id { get; set; }

        public string TermDesc { get; set; }
        public string GradeDesc { get; set; }
        public int TermDuration { get; set; }

        public double MaxTermPayment { get; set; }
        public double AvgTermPayment { get; set; }
        public long SettingId { get; set; }


    }

}
