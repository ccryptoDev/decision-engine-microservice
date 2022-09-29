using AutoMapper.Configuration;
using DecisionEngine.BAL.DTO;
using DecisionEngine.BAL.Interface;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Service
{
    public class OfferService : IOfferService
    {
        IOfferRepository _offerRepository;

        public OfferService(IOfferRepository offerRepository)
        {
            this._offerRepository = offerRepository;
        }
        public CreateResponseDTO CreateOffer(CreateOfferRequestDTO offerDTO)
        {
            Offer offer = Mapping.Mapper.Map<CreateOfferRequestDTO, Offer>(offerDTO);
            CreateResponse createResponse = _offerRepository.CreateOffer(offer);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public CreateResponseDTO UpdateOffer(OfferDTO offerDTO)
        {
            Offer offer = Mapping.Mapper.Map<OfferDTO, Offer>(offerDTO);
            CreateResponse createResponse = _offerRepository.UpdateOffer(offer);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;

        }
        public string DeleteOffer(int id)
        {
            return _offerRepository.DeleteOffer(id);

        }
        public OfferDTO LoadOfferById(int id)
        {
            Offer offer = _offerRepository.LoadOfferById(id);
            OfferDTO offerDTO = Mapping.Mapper.Map<Offer, OfferDTO>(offer);
            return offerDTO;


        }
        public List<OfferDTO> GetOffers(long settingId)
        {
            List<Offer> offers = _offerRepository.GetOffers(settingId);
            List<OfferDTO> offerDTOs = Mapping.Mapper.Map<List<Offer>, List<OfferDTO>>(offers);
            return offerDTOs;

        }
    }
}
