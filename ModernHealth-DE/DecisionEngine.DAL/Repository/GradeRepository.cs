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
    public class GradeRepository : BaseRepository, IGradeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public GradeRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateGrade(Grade grade)
        {

            try
            {
                grade.createdAt = DateTime.UtcNow;
                grade.active = true;
                _context.Grades.Add(grade);
                _context.SaveChanges();
                return new CreateResponse { id = grade.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = grade.Id, status = "failure" , message=Convert.ToString(ex.Message)};
                //throw ex;
            }
            finally
            {

            }

        }
        public CreateResponse UpdateGrade(Grade grade)
        {

            try
            {
                Grade entity = _context.Grades.FirstOrDefault(item => item.Id == grade.Id);
                entity.Description = grade.Description;
                entity.modifiedAt = DateTime.UtcNow;
                entity.SettingId = grade.SettingId;
                _context.SaveChanges();
                return new CreateResponse { id = grade.Id, status = "success" };
            }
            catch (Exception ex)
            {
                return new CreateResponse { id = grade.Id, status = "failure", message = Convert.ToString(ex.Message) };

                //throw ex;
            }
            finally
            {

            }

        }

        public string DeleteGrade(int id)
        {

            try
            {
                Grade entity = _context.Grades.FirstOrDefault(item => item.Id == id);
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

        public List<Grade> GetGrades(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,grade_description as Description,setting_id as SettingId from tbl_grade where active=true and coalesce(setting_id,0)=@settingId order by grade_description asc ";

                    var results = connection.Query<Grade>(gradeQuery,new { settingId = settingId});
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
        public Grade LoadGradeById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,grade_description as Description,setting_id as SettingId from tbl_grade where active=true and id=@id ";
                    var param = new { @id = id };
                    var results = connection.Query<Grade>(gradeQuery,param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new Grade();
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
