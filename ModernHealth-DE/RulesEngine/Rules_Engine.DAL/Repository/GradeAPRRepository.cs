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
   public class GradeAPRRepository : BaseRepository, IGradeAPRRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public GradeAPRRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateGradeAPR(GradeAPR grade)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                grade.createdAt = DateTime.UtcNow;
                grade.active = true;
                _context.GradeAPRs.Add(grade);
                _context.SaveChanges();
                createResponse.id = grade.Id;
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
        public string UpdateGradeAPR(GradeAPR grade)
        {

            try
            {
                GradeAPR entity = _context.GradeAPRs.FirstOrDefault(item => item.Id == grade.Id);
                entity.GradeValue = grade.GradeValue;
                entity.ScoreId = grade.ScoreId;
                entity.IncomeId = grade.IncomeId;
                entity.Apr = grade.Apr;
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

        public string DeleteGradeAPR(int id)
        {

            try
            {
                GradeAPR entity = _context.GradeAPRs.FirstOrDefault(item => item.Id == id);
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

        public List<GradeAPR> GetGradeAPRs()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,score_id as ScoreId,income_id as IncomeId,grade as GradeValue,apr as APR,active"
                        + " from tbl_gradeapr where active=true  ";

                    var results = connection.Query<GradeAPR>(gradeQuery);
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
        public GradeAPR LoadGradeAPRById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,score_id as ScoreId,income_id as IncomeId,grade as GradeValue,apr as APR,active"
                        + "  from tbl_gradeapr where active=true and id=@id  ";
                    var param = new { @id = id };
                    var results = connection.Query<GradeAPR>(gradeQuery, param);
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
