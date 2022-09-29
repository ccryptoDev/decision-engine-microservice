using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface ITermService
    {
        CreateResponseDTO CreateTerm(CreateTermRequestDTO term);
        string UpdateTerm(TermDTO term);
        List<TermDTO> GetTerms(long settingId);
        string DeleteTerm(int id);

        TermDTO LoadTermById(int id);
    }
}
