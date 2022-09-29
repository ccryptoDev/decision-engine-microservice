using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Interface
{
    public interface IOfferRepository
    {
        CreateResponse CreateOffer(Offer grade);
        CreateResponse UpdateOffer(Offer grade);
        List<Offer> GetOffers(long settingId);
        string DeleteOffer(int id);

        Offer LoadOfferById(int id);
    }
}
