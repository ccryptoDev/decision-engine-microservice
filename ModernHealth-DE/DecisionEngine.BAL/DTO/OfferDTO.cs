using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class OfferDTO
    {
        public long Id { get; set; }
        public string OfferLabel { get; set; }
        public long SettingId { get; set; }
    }
   
    public class CreateOfferRequestDTO
    {
        public string OfferLabel { get; set; }
        public long SettingId { get; set; }
    }
}
