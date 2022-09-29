using Dapper;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Context;
using DecisionEngine.Entities.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionEngine.DAL.Repository
{
    public class OfferRepository : BaseRepository, IOfferRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public OfferRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateOffer(Offer offer)
        {

            try
            {
                offer.createdAt = DateTime.UtcNow;
                offer.active = true;
                _context.Offers.Add(offer);
                _context.SaveChanges();
                return new CreateResponse { id = offer.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = offer.Id, status = "failure", message = Convert.ToString(ex.Message) };
                //throw ex;
            }
            finally
            {

            }

        }
        public CreateResponse UpdateOffer(Offer offer)
        {

            try
            {
                Offer entity = _context.Offers.FirstOrDefault(item => item.Id == offer.Id);
                entity.OfferLabel = offer.OfferLabel;
                entity.modifiedAt = DateTime.UtcNow;
                entity.SettingId = offer.SettingId;
                _context.SaveChanges();
                return new CreateResponse { id = offer.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = offer.Id, status = "failure", message = Convert.ToString(ex.Message) };

                //throw ex;
            }
            finally
            {

            }

        }

        public string DeleteOffer(int id)
        {

            try
            {
                Offer entity = _context.Offers.FirstOrDefault(item => item.Id == id);
                entity.active = false;
                _context.SaveChanges();
                return "success";
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }

        }

        public List<Offer> GetOffers(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerQuery = " select id,offer_label as OfferLabel,setting_id as SettingId from tbl_offer where active=true  and coalesce(setting_id,0)=@settingId  order by offer_label asc ";

                    var results = connection.Query<Offer>(offerQuery, new { settingId = settingId });
                    return results.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                pgCloseConnection();
            }

        }
        public Offer LoadOfferById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerQuery = " select id,offer_label as OfferLabel,setting_id as SettingId from tbl_offer where active=true and id=@id ";
                    var param = new { @id = id };
                    var results = connection.Query<Offer>(offerQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new Offer();
                    else
                        return offerValue;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                pgCloseConnection();
            }

        }
    }
}
