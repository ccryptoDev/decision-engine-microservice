using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
   public class GradeDTO
    {
           
            public long Id { get; set; }
          
            public long FromScore { get; set; }

            public long ToScore { get; set; }
            public double MinIncome { get; set; }
            public double MaxIncome { get; set; }
            public char GradeValue { get; set; }
            public double Apr { get; set; }
           

        }
    public class CreateReguestGradeDTO
    {

        

        public long FromScore { get; set; }

        public long ToScore { get; set; }
        public double MinIncome { get; set; }
        public double MaxIncome { get; set; }
        public char GradeValue { get; set; }
        public double Apr { get; set; }


    }

}
