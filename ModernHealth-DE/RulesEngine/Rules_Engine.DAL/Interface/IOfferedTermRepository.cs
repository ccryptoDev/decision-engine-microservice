using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
   public  interface IOfferedTermRepository
    {
        CreateResponse CreateOfferTerm(OfferedTerm request);
        string UpdateOfferedTerm(OfferedTerm request);
        List<OfferedTerm> GetOfferTerms(int offerLoanId);
        string DeleteOfferedTerm(int id);

        OfferedTerm LoadOfferedTermById(int id);
    }
}
