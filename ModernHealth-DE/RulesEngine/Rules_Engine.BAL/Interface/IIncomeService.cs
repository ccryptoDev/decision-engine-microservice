using Rules_Engine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Interface
{
  public  interface IIncomeService
    {
        CreateResponseDTO CreateIncome(CreateIncomeRequestDTO income);
        string UpdateIncome(UpdateIncomeRequestDTO income);
        List<IncomeDTO> GetIncomes();
        string DeleteIncome(int id);

        IncomeDTO LoadIncomeById(int id);
    }
}
