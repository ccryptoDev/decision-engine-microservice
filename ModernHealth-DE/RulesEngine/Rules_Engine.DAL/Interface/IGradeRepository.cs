using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
   public interface IGradeRepository
    {
        string CreateGrade(Grade grade);
        string UpdateGrade(Grade grade);
        List<Grade> GetGrades();
        string DeleteGrade(int id);

        Grade LoadGradeById(int id);
    }
}
