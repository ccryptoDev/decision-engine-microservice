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
   public class GradeAPRRepository : BaseRepository, IGradeAPRRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public GradeAPRRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
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
                entity.GradeId = grade.GradeId;
                entity.ScoreId = grade.ScoreId;
                entity.IncomeId = grade.IncomeId;
                entity.Apr = grade.Apr;
                entity.SettingId = grade.SettingId;
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

        public List<GradeAPR> GetGradeAPRs(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,score_id as ScoreId,income_id as IncomeId,grade_id as GradeId,apr as APR,active,setting_id as SettingId"
                        + " from tbl_gradeapr where active=true  and coalesce(setting_id,0)=@settingId ";

                    var results = connection.Query<GradeAPR>(gradeQuery, new { settingId = settingId });
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
        public List<GradeAPRDetail> GetGradeAPRDetails(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select ga.id,score_id as ScoreId,income_id as IncomeId,grade_id as GradeId,apr as APR,g.grade_description GradeValue,ga.setting_id as SettingId "
                        + " from tbl_gradeapr ga,tbl_grade g  where ga.grade_id=g.id and  ga.active=true  and coalesce(ga.setting_id,0)=@settingId";

                    var results = connection.Query<GradeAPRDetail>(gradeQuery,new { settingId = settingId });
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

                    string gradeQuery = " select id,score_id as ScoreId,income_id as IncomeId,grade_id as GradeId,apr as APR,active"
                        + "  from tbl_gradeapr where active=true and id=@id  ";
                    var param = new { @id = id };
                    var results = connection.Query<GradeAPR>(gradeQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new GradeAPR();
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
