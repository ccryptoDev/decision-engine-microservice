using DecisionEngine.BAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.BAL.Interface
{
    public interface IOfferValueService
    {
        CreateResponseDTO CreateOfferValue(CreateOfferValueRequestDTO offerValue);
        CreateResponseDTO UpdateOfferValue(OfferValueDTO offerValue);
        List<OfferValueDetailDTO> GetOfferValues(long settingId);
        string DeleteOfferValue(int id);
        OfferValueDetailDTO LoadOfferValueById(int id);
    }
}
