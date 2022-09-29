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
   public class TermGradeRepository : BaseRepository, ITermGradeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public TermGradeRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateTermGrade(TermGrade termGrade)
        {

            try
            {
                termGrade.createdAt = DateTime.UtcNow;
                termGrade.active = true;
                _context.TermGrades.Add(termGrade);
                _context.SaveChanges();
                return new CreateResponse { id = termGrade.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = termGrade.Id, status = "failure", message = Convert.ToString(ex.Message) };
                //throw ex;
            }
            finally
            {

            }

        }
        public CreateResponse UpdateTermGrade(TermGrade termGrade)
        {

            try
            {
                TermGrade entity = _context.TermGrades.FirstOrDefault(item => item.Id == termGrade.Id);
                entity.TermId = termGrade.TermId;
                entity.GradeId = termGrade.GradeId;
                entity.TermDuration = termGrade.TermDuration;
                entity.AvgTermPayment = termGrade.AvgTermPayment;
                entity.MaxTermPayment = termGrade.MaxTermPayment;
                entity.modifiedAt = DateTime.UtcNow;
                entity.SettingId = termGrade.SettingId;
                _context.SaveChanges();
                return new CreateResponse { id = termGrade.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = termGrade.Id, status = "failure", message = Convert.ToString(ex.Message) };

                //throw ex;
            }
            finally
            {

            }

        }

        public string DeleteTermGrade(int id)
        {

            try
            {
                TermGrade entity = _context.TermGrades.FirstOrDefault(item => item.Id == id);
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

        public List<TermGradeDetail> GetTermGrades(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string termGradeQuery = " select tg.id,t.term_description TermDesc,g.grade_description GradeDesc,tg.term_duration TermDuration,tg.avg_term_payment MaxTermPayment, "
                        + " tg.max_term_payment AvgTermPayment,tg.term_id,tg.grade_id,tg.setting_id as SettingId from tbl_term t, tbl_term_grade tg,tbl_grade g where t.id = tg.term_id and tg.grade_id = g.id "
+ " and t.active = true and tg.active = true and g.active=true  and coalesce(tg.setting_id,0)=@settingId";

                    var results = connection.Query<TermGradeDetail>(termGradeQuery, new { settingId = settingId });
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
        public TermGradeDetail LoadTermGradeById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string termGradeQuery = " select tg.id,t.term_description TermDesc,g.grade_description GradeDesc,tg.term_duration TermDuration,tg.avg_term_payment MaxTermPayment, "
                        + " tg.max_term_payment AvgTermPayment,tg.term_id,tg.grade_id,tg.setting_id as SettingId from tbl_term t, tbl_term_grade tg,tbl_grade g where t.id = tg.term_id and tg.grade_id = g.id "
+ " and t.active = true and tg.active = true and g.active=true and  tg.id =@id  ";
                    var param = new { @id = id };
                    var results = connection.Query<TermGradeDetail>(termGradeQuery, param);
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
