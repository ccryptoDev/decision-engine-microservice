using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.DTO
{
    public class ScoreDTO
    {
        public long Id { get; set; }

        public long FromScore { get; set; }

        public long ToScore { get; set; }
       
    }
    public class CreateScoreRequestDTO
    {
        public long FromScore { get; set; }

        public long ToScore { get; set; }
    }
    public class UpdateScoreRequestDTO
    {
        public long id { get; set; }
        public long FromScore { get; set; }

        public long ToScore { get; set; }
    }
    public class CreateResponseDTO
    {
        public string message { get; set; }
        public string status { get; set; }
        public long id { get; set; }
    }
}
