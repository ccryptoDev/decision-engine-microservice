using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
    public interface IOfferedTermService
    {
        CreateResponseDTO CreateOfferedTerm(CreateOfferedTermRequestDTO request);
        string UpdateOfferTerm(UpdateOfferedTermRequestDTO request);
        List<OfferedTermDTO> GetOfferTerms(int offerLoanId);
        string DeleteOfferTerm(int id);

        OfferedTermDTO LoadOfferedTermById(int id);
    }
}
