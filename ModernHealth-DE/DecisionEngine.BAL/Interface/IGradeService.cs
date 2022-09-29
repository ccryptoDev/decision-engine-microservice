using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
   public interface IGradeService
    {
        CreateResponseDTO CreateGrade(CreateReguestGradeDTO grade);
        CreateResponseDTO UpdateGrade(GradeDTO grade);
        List<GradeDTO> GetGrades(long settingId);
        string DeleteGrade(int id);
        GradeDTO LoadGradeById(int id);
    }
}
