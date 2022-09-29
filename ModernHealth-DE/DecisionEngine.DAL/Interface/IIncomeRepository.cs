using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
   public interface IIncomeRepository
    {
        CreateResponse CreateIncome(Income income);
        string UpdateIncome(Income income);
        List<Income> GetIncomes(long settingId);
        string DeleteIncome(int id);

        Income LoadIncomeById(int id);
    }
}
