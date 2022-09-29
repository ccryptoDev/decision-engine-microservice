
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
    public class GradeAPRService : IGradeAPRService
    {
        IGradeAPRRepository _gradeRepository;

        public GradeAPRService(IGradeAPRRepository gradeRepository, IConfiguration configuration)
        {
            this._gradeRepository = gradeRepository;
        }
        public CreateResponseDTO CreateGradeAPR(CreateGradeRequestDTO insertGradeAPRRequestDTO)
        {
            GradeAPR gradeAPR = Mapping.Mapper.Map<CreateGradeRequestDTO, GradeAPR>(insertGradeAPRRequestDTO);
            CreateResponse createResponse = _gradeRepository.CreateGradeAPR(gradeAPR);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateGradeAPR(UpdateGradeRequestDTO scoreDTO)
        {
            GradeAPR gradeAPR = Mapping.Mapper.Map<UpdateGradeRequestDTO, GradeAPR>(scoreDTO);
            return _gradeRepository.UpdateGradeAPR(gradeAPR);

        }
        public string DeleteGradeAPR(int id)
        {
            return _gradeRepository.DeleteGradeAPR(id);

        }
        public GradeAPRDTO LoadGradeAPRById(int id)
        {
            GradeAPR score = _gradeRepository.LoadGradeAPRById(id);
            GradeAPRDTO scoreDTO = Mapping.Mapper.Map<GradeAPR, GradeAPRDTO>(score);
            return scoreDTO;


        }
        public List<GradeAPRDTO> GetGradeAPRs()
        {
            List<GradeAPR> scores = _gradeRepository.GetGradeAPRs();
            List<GradeAPRDTO> scoreDTOs = Mapping.Mapper.Map<List<GradeAPR>, List<GradeAPRDTO>>(scores);
            return scoreDTOs;

        }
    }
}
