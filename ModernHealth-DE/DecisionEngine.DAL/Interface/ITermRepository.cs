using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
    public interface ITermRepository
    {
        CreateResponse CreateTerm(Term term);
        string UpdateTerm(Term term);
        List<TermDtl> GetTerms(long settingId);
        string DeleteTerm(int id);

        TermDtl LoadTermById(int id);
    }
}
