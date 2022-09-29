using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
  public  interface IScoreRepository
    {
        CreateResponse CreateScore(Score score);
        string UpdateScore(Score score);
        List<Score> GetScores();
        string DeleteScore(int id);

        Score LoadScoreById(int id);
    }
}
