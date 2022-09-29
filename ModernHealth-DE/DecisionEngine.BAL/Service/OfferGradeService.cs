using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
    public class OfferGradeService : IOfferGradeService
    {
        IOfferGradeRepository _gradeRepository;

        public OfferGradeService(IOfferGradeRepository gradeRepository)
        {
            this._gradeRepository = gradeRepository;
        }
        public CreateResponseDTO CreateOfferGrade(CreateOfferGradeRequestDTO insertOfferGradeRequestDTO)
        {
            OfferGrade offerGrade = Mapping.Mapper.Map<CreateOfferGradeRequestDTO, OfferGrade>(insertOfferGradeRequestDTO);
            CreateResponse createResponse = _gradeRepository.CreateOfferGrade(offerGrade);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string UpdateOfferGrade(UpdateGradeRequestDTO offerGradeDTO)
        {
            OfferGrade offerGrade = Mapping.Mapper.Map<UpdateGradeRequestDTO, OfferGrade>(offerGradeDTO);
            return _gradeRepository.UpdateOfferGrade(offerGrade);

        }
        public string DeleteOfferGrade(int id)
        {
            return _gradeRepository.DeleteOfferGrade(id);

        }
        public OfferGradeDTO LoadOfferGradeById(int id)
        {
            OfferGradeDetail offerGrade = _gradeRepository.LoadOfferGradeById(id);
            OfferGradeDTO offerGradeDTO = Mapping.Mapper.Map<OfferGradeDetail, OfferGradeDTO>(offerGrade);
            return offerGradeDTO;


        }
        public List<OfferGradeDTO> GetOfferGrades(long settingId)
        {
            List<OfferGradeDetail> offerGrades = _gradeRepository.GetOfferGrades(settingId);
            List<OfferGradeDTO> offerGradeDTOs = Mapping.Mapper.Map<List<OfferGradeDetail>, List<OfferGradeDTO>>(offerGrades);
            return offerGradeDTOs;

        }

        public GradeAvgsDTO GetGradeAvgs(long grade_id, long settingId)
        {
            GradeAvgs offerGradeDetails = _gradeRepository.GetGradeAvgs(grade_id, settingId);
            GradeAvgsDTO offerGradeDetailDTOs = Mapping.Mapper.Map<GradeAvgs, GradeAvgsDTO>(offerGradeDetails);
            return offerGradeDetailDTOs;

        }
        public List<ResponseOfferValueDTO> GetOfferValues(long offer_id)
        {
            List<ResponseOfferValue> offerGradeDetails = _gradeRepository.GetOfferValues(offer_id);
            List<ResponseOfferValueDTO> offerGradeDetailDTOs = Mapping.Mapper.Map<List<ResponseOfferValue>, List<ResponseOfferValueDTO>>(offerGradeDetails);
            return offerGradeDetailDTOs;

        }
    }
}
