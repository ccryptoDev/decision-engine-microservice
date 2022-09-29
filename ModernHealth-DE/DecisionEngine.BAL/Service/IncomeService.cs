using Microsoft.Extensions.Configuration;
using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
  public  class IncomeService : IIncomeService
    {
        IIncomeRepository _gradeRepository;

        public IncomeService(IIncomeRepository gradeRepository, IConfiguration configuration)
        {
            this._gradeRepository = gradeRepository;
        }
        public CreateResponseDTO CreateIncome(CreateIncomeRequestDTO insertIncomeRequestDTO)
        {
            Income income = Mapping.Mapper.Map<CreateIncomeRequestDTO, Income>(insertIncomeRequestDTO);
            CreateResponse createResponse = _gradeRepository.CreateIncome(income);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateIncome(UpdateIncomeRequestDTO incomeDTO)
        {
            Income income = Mapping.Mapper.Map<UpdateIncomeRequestDTO, Income>(incomeDTO);
            return _gradeRepository.UpdateIncome(income);

        }
        public string DeleteIncome(int id)
        {
            return _gradeRepository.DeleteIncome(id);

        }
        public IncomeDTO LoadIncomeById(int id)
        {
            Income income = _gradeRepository.LoadIncomeById(id);
            IncomeDTO incomeDTO = Mapping.Mapper.Map<Income, IncomeDTO>(income);
            return incomeDTO;


        }
        public List<IncomeDTO> GetIncomes(long settingId)
        {
            List<Income> incomes = _gradeRepository.GetIncomes(settingId);
            List<IncomeDTO> incomeDTOs = Mapping.Mapper.Map<List<Income>, List<IncomeDTO>>(incomes);
            return incomeDTOs;

        }
    }
}
