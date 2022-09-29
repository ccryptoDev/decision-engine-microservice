using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface IOfferService
    {
        CreateResponseDTO CreateOffer(CreateOfferRequestDTO grade);
        CreateResponseDTO UpdateOffer(OfferDTO grade);
        List<OfferDTO> GetOffers(long settingId);
        string DeleteOffer(int id);
        OfferDTO LoadOfferById(int id);
    }
}
