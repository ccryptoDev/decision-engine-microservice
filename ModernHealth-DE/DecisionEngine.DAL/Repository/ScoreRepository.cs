using Dapper;
using Microsoft.Extensions.Configuration;
using DecisionEngine.DAL.Interface;
using DecisionEngine.Entities.Context;
using DecisionEngine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecisionEngine.DAL.Repository
{
   public class ScoreRepository : BaseRepository, IScoreRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public ScoreRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateScore(Score score)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                score.createdAt = DateTime.UtcNow;
                score.active = true;
                _context.Scores.Add(score);
                _context.SaveChanges();
                createResponse.id = score.Id;
                createResponse.message = "";
                createResponse.status = "success";
                return createResponse;
            }
            catch (Exception ex)
            {
                createResponse.id =0;
                createResponse.message = Convert.ToString(ex.Message);
                createResponse.status = "failure";
                return createResponse;
                throw ex;
            }
            finally
            {
               
            }

        }
        public string UpdateScore(Score score)
        {

            try
            {
                Score entity = _context.Scores.FirstOrDefault(item => item.Id == score.Id);
                entity.FromScore = score.FromScore;
                entity.ToScore = score.ToScore;
                entity.offerId = score.offerId;
                entity.SettingId = score.SettingId;
                entity.modifiedAt = DateTime.UtcNow;
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

        public string DeleteScore(int id)
        {

            try
            {
                Score entity = _context.Scores.FirstOrDefault(item => item.Id == id);
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

        public List<Score> GetScores(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string scoreQuery = " select a.id,a.from_score as FromScore,a.to_score as ToScore,a.active,a.offer_id,b.offer_Label as offerLabel,a.setting_id as SettingId "
                        + " from tbl_score a left join tbl_offer b  on a.offer_id=b.id and b.active=true where a.active=true and coalesce(a.setting_id,0)=@settingId order by a.from_score desc ";

                    var results = connection.Query<Score>(scoreQuery, new { settingId = settingId });
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
        public Score LoadScoreById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select a.id,a.from_score as FromScore,a.to_score as ToScore,a.active,a.offer_id,b.offer_Label as offerLabel,a.setting_id as SettingId"
                        + "  from tbl_score a left join tbl_offer b  on a.offer_id=b.id and b.active=true where a.active=true and a.id=@id order by a.from_score desc ";
                    var param = new { @id = id };
                    var results = connection.Query<Score>(gradeQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new Score();
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
