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
    public class OfferValueRepository : BaseRepository, IOfferValueRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public OfferValueRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateOfferValue(OfferValue offerValue)
        {

            try
            {
                offerValue.createdAt = DateTime.UtcNow;
                offerValue.active = true;
                _context.OfferValues.Add(offerValue);
                _context.SaveChanges();
                return new CreateResponse { id = offerValue.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = offerValue.Id, status = "failure", message = Convert.ToString(ex.Message) };
                //throw ex;
            }
            finally
            {

            }

        }
        public CreateResponse UpdateOfferValue(OfferValue offerValue)
        {

            try
            {
                OfferValue entity = _context.OfferValues.FirstOrDefault(item => item.Id == offerValue.Id);
                entity.OfferId = offerValue.OfferId;
                entity.Value = offerValue.Value;
                entity.modifiedAt = DateTime.UtcNow;
                _context.SaveChanges();
                return new CreateResponse { id = offerValue.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = offerValue.Id, status = "failure", message = Convert.ToString(ex.Message) };

                //throw ex;
            }
            finally
            {

            }

        }

        public string DeleteOfferValue(int id)
        {

            try
            {
                OfferValue entity = _context.OfferValues.FirstOrDefault(item => item.Id == id);
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

        public List<OfferValueDetail> GetOfferValues(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerValueQuery = " select ov.id,ov.offer_value as Value,o.offer_label as OfferLabel,ov.offer_id as OfferId,ov.setting_id as SettingId from tbl_offer_value ov inner join tbl_offer o on "
                        + " ov.offer_id=o.id where ov.active=true and ov.setting_id=o.setting_id and coalesce(ov.setting_id,0)=@settingId order by ov.offer_value asc ";

                    var results = connection.Query<OfferValueDetail>(offerValueQuery, new { settingId = settingId });
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
        public OfferValueDetail LoadOfferValueById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerValueQuery = " select ov.id,ov.offer_value as Value,o.offer_label as OfferLabel,ov.offer_id as OfferId,ov.setting_id as SettingId from tbl_offer_value ov inner join tbl_offer o on "
                        + " ov.offer_id=o.id where ov.active=true and ov.setting_id=o.setting_id and ov.id =@id  order by ov.offer_value asc ";
                    var param = new { @id = id };
                    var results = connection.Query<OfferValueDetail>(offerValueQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new OfferValueDetail();
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
