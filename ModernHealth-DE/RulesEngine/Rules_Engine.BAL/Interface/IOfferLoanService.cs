using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
   public interface IOfferLoanService
    {
        CreateResponseDTO CreateOfferLoan(CreateOfferLoanRequestDTO income);
        string UpdateOfferLoan(UpdateOfferLoanRequestDTO income);
        List<OfferLoanDTO> GetOfferLoans();
        string DeleteOfferLoan(int id);

        OfferLoanDTO LoadOfferLoanById(int id);
        List<Dictionary<string, object>> GetOfferLoansWithTerms(string grade = null);
    }
}
