using Dapper;
using Microsoft.Extensions.Configuration;
using Rules_Engine.DAL.Interface;
using Rules_Engine.Entities.Context;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules_Engine.DAL.Repository
{
   public class ScoreRepository : BaseRepository, IScoreRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public ScoreRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
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

        public List<Score> GetScores()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string scoreQuery = " select id,from_score as FromScore,to_score as ToScore,active"
                        +" from tbl_score where active=true order by from_score desc ";

                    var results = connection.Query<Score>(scoreQuery);
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

                    string gradeQuery = " select id,from_score as FromScore,to_score as ToScore,active"
                        + "  from tbl_score where active=true and id=@id order by from_score desc ";
                    var param = new { @id = id };
                    var results = connection.Query<Score>(gradeQuery, param);
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
    }
}
