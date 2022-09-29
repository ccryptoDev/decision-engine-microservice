using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
   public class GradeDTO
    {
           
         public long Id { get; set; }
          public string Description { get; set; }
        public long SettingId { get; set; }

    }
    public class CreateReguestGradeDTO
    {
        public string Description { get; set; }
        public long SettingId { get; set; }
    }

}
