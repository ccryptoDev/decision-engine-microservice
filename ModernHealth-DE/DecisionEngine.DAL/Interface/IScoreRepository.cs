using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
  public  interface IScoreRepository
    {
        CreateResponse CreateScore(Score score);
        string UpdateScore(Score score);
        List<Score> GetScores(long settingId);
        string DeleteScore(int id);

        Score LoadScoreById(int id);
    }
}
