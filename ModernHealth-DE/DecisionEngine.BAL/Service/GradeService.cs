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
  public  class GradeService : IGradeService
    {
        IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository, IConfiguration configuration)
        {
            this._gradeRepository = gradeRepository;
        }
        public CreateResponseDTO CreateGrade(CreateReguestGradeDTO gradeDTO)
        {
            Grade grade = Mapping.Mapper.Map<CreateReguestGradeDTO, Grade>(gradeDTO);
            CreateResponse createResponse= _gradeRepository.CreateGrade(grade);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public CreateResponseDTO UpdateGrade(GradeDTO gradeDTO)
        {
            Grade grade = Mapping.Mapper.Map<GradeDTO, Grade>(gradeDTO);
            CreateResponse createResponse= _gradeRepository.UpdateGrade(grade);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string DeleteGrade(int id)
        {
            return _gradeRepository.DeleteGrade(id);

        }
        public GradeDTO LoadGradeById(int id)
        {
            Grade grade= _gradeRepository.LoadGradeById(id);
            GradeDTO gradeDTO = Mapping.Mapper.Map<Grade, GradeDTO>(grade);
            return gradeDTO;


        }
        public List<GradeDTO> GetGrades(long settingId)
        {
            List<Grade> grades = _gradeRepository.GetGrades(settingId);
            List<GradeDTO> gradeDTOs = Mapping.Mapper.Map<List<Grade>, List<GradeDTO>>(grades);
            return gradeDTOs;

        }
    }
}
