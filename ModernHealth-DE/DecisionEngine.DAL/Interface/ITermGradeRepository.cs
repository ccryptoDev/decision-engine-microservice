using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
  public  interface ITermGradeRepository
    {
        CreateResponse CreateTermGrade(TermGrade grade);
        CreateResponse UpdateTermGrade(TermGrade grade);
        List<TermGradeDetail> GetTermGrades(long settingId);
        string DeleteTermGrade(int id);

        TermGradeDetail LoadTermGradeById(int id);
    }
}
