using Microsoft.Extensions.Configuration;
using Rules_Engine.BAL.DTO;
using Rules_Engine.BAL.Interface;
using Rules_Engine.DAL.Interface;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.BAL.Service
{
  public  class GradeService : IGradeService
    {
        IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository, IConfiguration configuration)
        {
            this._gradeRepository = gradeRepository;
        }
        public string CreateGrade(CreateReguestGradeDTO gradeDTO)
        {
            Grade grade = Mapping.Mapper.Map<CreateReguestGradeDTO, Grade>(gradeDTO);
            return _gradeRepository.CreateGrade(grade);

        }
        public string UpdateGrade(GradeDTO gradeDTO)
        {
            Grade grade = Mapping.Mapper.Map<GradeDTO, Grade>(gradeDTO);
            return _gradeRepository.UpdateGrade(grade);

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
        public List<GradeDTO> GetGrades()
        {
            List<Grade> grades = _gradeRepository.GetGrades();
            List<GradeDTO> gradeDTOs = Mapping.Mapper.Map<List<Grade>, List<GradeDTO>>(grades);
            return gradeDTOs;

        }
    }
}
