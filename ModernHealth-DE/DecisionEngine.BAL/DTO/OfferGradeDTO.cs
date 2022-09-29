using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class OfferGradeDTO
    {
            public long Id { get; set; }


            public long offer_value_id { get; set; }

            public long grade_id { get; set; }

            public string offer_label { get; set; }

            public string offer_value { get; set; }

            public string grade_description { get; set; }


            public double min_apr { get; set; }

            public double max_apr { get; set; }
        public long SettingId { get; set; }

        public double avg_apr { get; set; }

    }
    public class CreateOfferGradeRequestDTO
    {
        public long GradeId { get; set; }

        public long OfferValueId { get; set; }
        public double MinAPR { get; set; }
       
        public double MaxAPR { get; set; }
       
        public double AvgAPR { get; set; }
        public long SettingId { get; set; }

    }
    public class GradeAvgsDTO
    {
        public long GradeId { get; set; }
        public double MinAPR { get; set; }

        public double MaxAPR { get; set; }

         public double AvgAPR { get; set; }
        public long SettingId { get; set; }

    }

    public class ResponseOfferValueDTO
    {
        public long id { get; set; }
        public string offer_value { get; set; }

    }
}
