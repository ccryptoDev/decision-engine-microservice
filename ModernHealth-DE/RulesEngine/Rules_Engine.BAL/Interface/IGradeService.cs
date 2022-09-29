using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
   public interface IGradeService
    {
        string CreateGrade(CreateReguestGradeDTO grade);
        string UpdateGrade(GradeDTO grade);
        List<GradeDTO> GetGrades();
        string DeleteGrade(int id);
        GradeDTO LoadGradeById(int id);
    }
}
