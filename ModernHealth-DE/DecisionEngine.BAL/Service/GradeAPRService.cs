

using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
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
        public string UpdateGradeAPR(UpdateGradeRequestDTO gradeAPRDTO)
        {
            GradeAPR gradeAPR = Mapping.Mapper.Map<UpdateGradeRequestDTO, GradeAPR>(gradeAPRDTO);
            return _gradeRepository.UpdateGradeAPR(gradeAPR);

        }
        public string DeleteGradeAPR(int id)
        {
            return _gradeRepository.DeleteGradeAPR(id);

        }
        public GradeAPRDTO LoadGradeAPRById(int id)
        {
            GradeAPR gradeAPR = _gradeRepository.LoadGradeAPRById(id);
            GradeAPRDTO gradeAPRDTO = Mapping.Mapper.Map<GradeAPR, GradeAPRDTO>(gradeAPR);
            return gradeAPRDTO;


        }
        public List<GradeAPRDTO> GetGradeAPRs(long settingId)
        {
            List<GradeAPR> gradeAPRs = _gradeRepository.GetGradeAPRs(settingId);
            List<GradeAPRDTO> gradeAPRDTOs = Mapping.Mapper.Map<List<GradeAPR>, List<GradeAPRDTO>>(gradeAPRs);
            return gradeAPRDTOs;

        }

        public List<GradeAPRDetailDTO> GetGradeAPRDetails(long settingId)
        {
            List<GradeAPRDetail> gradeAPRDetails = _gradeRepository.GetGradeAPRDetails(settingId);
            List<GradeAPRDetailDTO> gradeAPRDetailDTOs = Mapping.Mapper.Map<List<GradeAPRDetail>, List<GradeAPRDetailDTO>>(gradeAPRDetails);
            return gradeAPRDetailDTOs;

        }
    }
}
