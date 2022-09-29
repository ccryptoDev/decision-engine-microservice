using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class TermDTO
    {
        public long Id { get; set; }

        public long SettingId { get; set; }
        public string description { get; set; }
    }
    public class CreateTermRequestDTO
    {
        public long SettingId { get; set; }
        public string description { get; set; }
    }
}
