using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
  public  interface IIncomeService
    {
        CreateResponseDTO CreateIncome(CreateIncomeRequestDTO income);
        string UpdateIncome(UpdateIncomeRequestDTO income);
        List<IncomeDTO> GetIncomes(long settingId);
        string DeleteIncome(int id);

        IncomeDTO LoadIncomeById(int id);
    }
}
