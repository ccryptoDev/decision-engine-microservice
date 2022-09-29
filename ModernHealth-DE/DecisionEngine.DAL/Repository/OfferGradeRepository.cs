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
    public class OfferGradeRepository : BaseRepository, IOfferGradeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public OfferGradeRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateOfferGrade(OfferGrade offerGrade)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                offerGrade.createdAt = DateTime.UtcNow;
                offerGrade.active = true;
                _context.OfferGrades.Add(offerGrade);
                _context.SaveChanges();
                createResponse.id = offerGrade.Id;
                createResponse.message = "";
                createResponse.status = "success";
                return createResponse;
            }
            catch (Exception ex)
            {
                createResponse.id = 0;
                createResponse.message = Convert.ToString(ex.Message);
                createResponse.status = "failure";
                return createResponse;
                throw ex;
            }
            finally
            {

            }

        }
        public string UpdateOfferGrade(OfferGrade offerGrade)
        {

            try
            {
                OfferGrade entity = _context.OfferGrades.FirstOrDefault(item => item.Id == offerGrade.Id);
                entity.GradeId = offerGrade.GradeId;
                entity.OfferValueId = offerGrade.OfferValueId;
                entity.MinAPR = offerGrade.MinAPR;
                entity.MaxAPR = offerGrade.MaxAPR;
                entity.AvgAPR = offerGrade.AvgAPR;
                entity.modifiedAt = DateTime.UtcNow;
                entity.SettingId = offerGrade.SettingId;
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

        public string DeleteOfferGrade(int id)
        {

            try
            {
                OfferGrade entity = _context.OfferGrades.FirstOrDefault(item => item.Id == id);
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

        public List<OfferGradeDetail> GetOfferGrades(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerGradeQuery = " select og.id,og.grade_id , og.offer_value_id , min_apr,max_apr,avg_apr , ov.offer_value,g.grade_description,o.offer_label,og.setting_id as SettingId  from  tbl_offer_grade og, tbl_offer_value ov ,tbl_grade g,tbl_offer o "
+ " where og.offer_value_id = ov.id and og.grade_id = g.id and o.id=ov.offer_id and o.active=true and og.active = true and g.active = true and ov.active = true   and coalesce(og.setting_id,0)=@settingId";

                    var results = connection.Query<OfferGradeDetail>(offerGradeQuery, new { settingId = settingId });
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
       
        public OfferGradeDetail LoadOfferGradeById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerGradeQuery = " select og.id,og.grade_id , og.offer_value_id , min_apr,max_apr,avg_apr , ov.offer_value,g.grade_description,o.offer_label,og.setting_id as SettingId from  tbl_offer_grade og, tbl_offer_value ov ,tbl_grade g,tbl_offer o "
+ " where og.offer_value_id = ov.id and og.grade_id = g.id and o.id=ov.offer_id and o.active=true and og.active = true and g.active = true and ov.active = true  and og.id=@id  ";
                    var param = new { @id = id };
                    var results = connection.Query<OfferGradeDetail>(offerGradeQuery, param);
                    return results.FirstOrDefault();
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

        public GradeAvgs GetGradeAvgs(long grade_id, long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerGradeQuery = "select min(apr) as MinApr, max(apr) as MaxApr , avg(apr) AvgApr,ga.grade_id GradeId,ga.setting_id as SettingId"
+ " from tbl_gradeapr ga, tbl_grade g where ga.grade_id = g.id and ga.active = true and g.active = true and ga.grade_id = @id and coalesce(ga.setting_id,0)=@settingId group by ga.grade_id ,ga.setting_id  ";
                    var param = new { @id = grade_id , @settingId = settingId };
                    var results = connection.Query<GradeAvgs>(offerGradeQuery, param);
                    if (results.Count() == 0)
                        return new GradeAvgs();
                    else
                        return results.FirstOrDefault();
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

        public List<ResponseOfferValue> GetOfferValues(long offer_id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string offerGradeQuery = "select id, offer_value from tbl_offer_value where offer_id = @id and active = true ";
                    var param = new { @id = offer_id };
                    var results = connection.Query<ResponseOfferValue>(offerGradeQuery, param);
                    return results.ToList(); ;
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
