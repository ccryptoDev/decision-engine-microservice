using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
    public class OfferValueService : IOfferValueService
    {
        IOfferValueRepository _offerValueRepository;

        public OfferValueService(IOfferValueRepository offerValueRepository)
        {
            this._offerValueRepository = offerValueRepository;
        }
        public CreateResponseDTO CreateOfferValue(CreateOfferValueRequestDTO offerValueDTO)
        {
            OfferValue offerValue = Mapping.Mapper.Map<CreateOfferValueRequestDTO, OfferValue>(offerValueDTO);
            CreateResponse createResponse = _offerValueRepository.CreateOfferValue(offerValue);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public CreateResponseDTO UpdateOfferValue(OfferValueDTO offerValueDTO)
        {
            OfferValue offerValue = Mapping.Mapper.Map<OfferValueDTO, OfferValue>(offerValueDTO);
            CreateResponse createResponse = _offerValueRepository.UpdateOfferValue(offerValue);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string DeleteOfferValue(int id)
        {
            return _offerValueRepository.DeleteOfferValue(id);

        }
        public OfferValueDetailDTO LoadOfferValueById(int id)
        {
            OfferValueDetail offerValue = _offerValueRepository.LoadOfferValueById(id);
            OfferValueDetailDTO offerValueDTO = Mapping.Mapper.Map<OfferValueDetail, OfferValueDetailDTO>(offerValue);
            return offerValueDTO;


        }
        public List<OfferValueDetailDTO> GetOfferValues(long settingId)
        {
            List<OfferValueDetail> offerValues = _offerValueRepository.GetOfferValues(settingId);
            List<OfferValueDetailDTO> offerValueDTOs = Mapping.Mapper.Map<List<OfferValueDetail>, List<OfferValueDetailDTO>>(offerValues);
            return offerValueDTOs;

        }
    }
}
