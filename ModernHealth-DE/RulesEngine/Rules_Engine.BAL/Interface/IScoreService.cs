using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
  public  interface IScoreService
    {
        CreateResponseDTO CreateScore(CreateScoreRequestDTO score);
        string UpdateScore(UpdateScoreRequestDTO score);
        List<ScoreDTO> GetScores();
        string DeleteScore(int id);

        ScoreDTO LoadScoreById(int id);
    }
}
