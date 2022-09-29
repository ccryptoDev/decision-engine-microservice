using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface ITermGradeService
    {
        CreateResponseDTO CreateTermGrade(CreateTermGradeRequestDTO termGrade);
        CreateResponseDTO UpdateTermGrade(TermGradeDTO termGrade);
        List<TermGradeDetailDTO> GetTermGrades(long settingId);
        string DeleteTermGrade(int id);
        TermGradeDetailDTO LoadTermGradeById(int id);
    }
}
