using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
   public interface IGradeRepository
    {
        CreateResponse CreateGrade(Grade grade);
        CreateResponse UpdateGrade(Grade grade);
        List<Grade> GetGrades(long settingId);
        string DeleteGrade(int id);

        Grade LoadGradeById(int id);
    }
}
