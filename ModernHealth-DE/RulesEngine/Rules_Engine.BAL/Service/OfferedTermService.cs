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
    public class OfferedTermService : IOfferedTermService
    {
        IOfferedTermRepository _offerLoanRepository;
        public OfferedTermService(IOfferedTermRepository offerLoanRepository, IConfiguration configuration)
        {
            this._offerLoanRepository = offerLoanRepository;
        }

        public CreateResponseDTO CreateOfferedTerm(CreateOfferedTermRequestDTO request)
        {
            OfferedTerm offeredTerm = Mapping.Mapper.Map<CreateOfferedTermRequestDTO, OfferedTerm>(request);
            CreateResponse createResponse = _offerLoanRepository.CreateOfferTerm(offeredTerm);
            CreateResponseDTO createResponseDTO = Mapping.Mapper.Map<CreateResponse, CreateResponseDTO>(createResponse);
            return createResponseDTO;
        }

        public string DeleteOfferTerm(int id)
        {
            return _offerLoanRepository.DeleteOfferedTerm(id);
        }

        public List<OfferedTermDTO> GetOfferTerms(int offerLoanId)
        {
            List<OfferedTerm> offeredTerms = _offerLoanRepository.GetOfferTerms(offerLoanId);
            List<OfferedTermDTO> offerTermDTOs = Mapping.Mapper.Map<List<OfferedTerm>, List<OfferedTermDTO>>(offeredTerms);
            return offerTermDTOs;
        }

        public OfferedTermDTO LoadOfferedTermById(int id)
        {
            OfferedTerm offeredTerm = _offerLoanRepository.LoadOfferedTermById(id);
            OfferedTermDTO offerTermDTO = Mapping.Mapper.Map<OfferedTerm, OfferedTermDTO>(offeredTerm);
            return offerTermDTO;
        }

        public string UpdateOfferTerm(UpdateOfferedTermRequestDTO request)
        {
            var offeredTerm = Mapping.Mapper.Map<UpdateOfferedTermRequestDTO, OfferedTerm>(request);
            return _offerLoanRepository.UpdateOfferedTerm(offeredTerm);
        }
    }
}
