using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.DTO
{
    public class ScoreDTO
    {
        public long Id { get; set; }

        public long FromScore { get; set; }

        public long ToScore { get; set; }
        public string offerLabel { get; set; }
        public long SettingId { get; set; }

    }
    public class CreateScoreRequestDTO
    {
        public long FromScore { get; set; }

        public long ToScore { get; set; }

        public long? offerId { get; set; }
        public long SettingId { get; set; }
    }
    public class UpdateScoreRequestDTO
    {
        public long id { get; set; }
        public long FromScore { get; set; }

        public long ToScore { get; set; }
        public long? offerId { get; set; }
        public long SettingId { get; set; }
    }
    public class CreateResponseDTO
    {
        public string message { get; set; }
        public string status { get; set; }
        public long id { get; set; }

    }
}
