using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
    public class TermService : ITermService
    {
        ITermRepository _gradeRepository;

        public TermService(ITermRepository gradeRepository)
        {
            this._gradeRepository = gradeRepository;
        }
        public CreateResponseDTO CreateTerm(CreateTermRequestDTO insertTermRequestDTO)
        {
            Term income = Mapping.Mapper.Map<CreateTermRequestDTO, Term>(insertTermRequestDTO);
            CreateResponse createResponse = _gradeRepository.CreateTerm(income);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateTerm(TermDTO incomeDTO)
        {
            Term income = Mapping.Mapper.Map<TermDTO, Term>(incomeDTO);
            return _gradeRepository.UpdateTerm(income);

        }
        public string DeleteTerm(int id)
        {
            return _gradeRepository.DeleteTerm(id);

        }
        public TermDTO LoadTermById(int id)
        {
            TermDtl income = _gradeRepository.LoadTermById(id);
            TermDTO incomeDTO = Mapping.Mapper.Map<TermDtl, TermDTO>(income);
            return incomeDTO;


        }
        public List<TermDTO> GetTerms(long settingId)
        {
            List<TermDtl> incomes = _gradeRepository.GetTerms(settingId);
            List<TermDTO> incomeDTOs = Mapping.Mapper.Map<List<TermDtl>, List<TermDTO>>(incomes);
            return incomeDTOs;

        }

    }
}
