using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
  
    public class OfferValueDTO
    {
        public long Id { get; set; }

        public long OfferId { get; set; }

        public string Value { get; set; }
        public long SettingId { get; set; }

    }
    public class CreateOfferValueRequestDTO
    {
        public long OfferId { get; set; }
        public long SettingId { get; set; }
        public string Value { get; set; }
    }
  
    public class OfferValueDetailDTO
    {
        public long SettingId { get; set; }

        public long Id { get; set; }

        public long OfferId { get; set; }

        public string Value { get; set; }
        
        public string OfferLabel { get; set; }


    }

}
