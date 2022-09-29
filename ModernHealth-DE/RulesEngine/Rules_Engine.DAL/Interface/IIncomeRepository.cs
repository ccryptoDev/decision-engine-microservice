using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.DAL.Interface
{
   public interface IIncomeRepository
    {
        CreateResponse CreateIncome(Income income);
        string UpdateIncome(Income income);
        List<Income> GetIncomes();
        string DeleteIncome(int id);

        Income LoadIncomeById(int id);
    }
}
