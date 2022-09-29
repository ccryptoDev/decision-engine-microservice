using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
  public  interface IScoreService
    {
        CreateResponseDTO CreateScore(CreateScoreRequestDTO score);
        string UpdateScore(UpdateScoreRequestDTO score);
        List<ScoreDTO> GetScores(long settingId);
        string DeleteScore(int id);

        ScoreDTO LoadScoreById(int id);
    }
}
