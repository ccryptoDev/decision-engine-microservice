using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
    public class TermGradeService : ITermGradeService
    {
        ITermGradeRepository _termGradeRepository;

        public TermGradeService(ITermGradeRepository termGradeRepository)
        {
            this._termGradeRepository = termGradeRepository;
        }
        public CreateResponseDTO CreateTermGrade(CreateTermGradeRequestDTO termGradeDTO)
        {
            TermGrade termGrade = Mapping.Mapper.Map<CreateTermGradeRequestDTO, TermGrade>(termGradeDTO);
            CreateResponse createResponse = _termGradeRepository.CreateTermGrade(termGrade);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public CreateResponseDTO UpdateTermGrade(TermGradeDTO termGradeDTO)
        {
            TermGrade termGrade = Mapping.Mapper.Map<TermGradeDTO, TermGrade>(termGradeDTO);
            CreateResponse createResponse = _termGradeRepository.UpdateTermGrade(termGrade);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string DeleteTermGrade(int id)
        {
            return _termGradeRepository.DeleteTermGrade(id);

        }
        public TermGradeDetailDTO LoadTermGradeById(int id)
        {
            TermGradeDetail termGrade = _termGradeRepository.LoadTermGradeById(id);
            TermGradeDetailDTO termGradeDTO = Mapping.Mapper.Map<TermGradeDetail, TermGradeDetailDTO>(termGrade);
            return termGradeDTO;


        }
        public List<TermGradeDetailDTO> GetTermGrades(long settingId)
        {
            List<TermGradeDetail> termGrades = _termGradeRepository.GetTermGrades(settingId);
            List<TermGradeDetailDTO> termGradeDTOs = Mapping.Mapper.Map<List<TermGradeDetail>, List<TermGradeDetailDTO>>(termGrades);
            return termGradeDTOs;

        }
    }
}
