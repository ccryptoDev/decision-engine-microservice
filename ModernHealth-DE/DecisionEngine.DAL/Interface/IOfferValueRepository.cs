using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
    public interface IOfferValueRepository
    {
        CreateResponse CreateOfferValue(OfferValue grade);
        CreateResponse UpdateOfferValue(OfferValue grade);
        List<OfferValueDetail> GetOfferValues(long settingId);
        string DeleteOfferValue(int id);

        OfferValueDetail LoadOfferValueById(int id);
    }
}
