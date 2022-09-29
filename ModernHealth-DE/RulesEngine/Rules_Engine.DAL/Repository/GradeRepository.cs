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
    public class GradeRepository : BaseRepository, IGradeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public GradeRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public string CreateGrade(Grade grade)
        {

            try
            {
                grade.createdAt = DateTime.UtcNow;
                grade.active = true;
                _context.Grades.Add(grade);
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
        public string UpdateGrade(Grade grade)
        {

            try
            {
                Grade entity = _context.Grades.FirstOrDefault(item => item.Id == grade.Id);
                entity.FromScore = grade.FromScore;
                entity.ToScore = grade.ToScore;
                entity.MinIncome = grade.MinIncome;
                entity.MaxIncome = grade.MaxIncome;
                entity.modifiedAt = DateTime.UtcNow;
                entity.GradeValue = grade.GradeValue;
                entity.Apr = grade.Apr;
              
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

        public List<Grade> GetGrades()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string gradeQuery = " select id,from_score as FromScore,to_score as ToScore,min_income as MinIncome,"
                        +" max_income as MaxIncome,grade as GradeValue , apr as Apr from tbl_grade where active=true order by from_score desc ";

                    var results = connection.Query<Grade>(gradeQuery);
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

                    string gradeQuery = " select id,from_score as FromScore,to_score as ToScore,min_income as MinIncome,"
                        + " max_income as MaxIncome,grade as GradeValue , apr as Apr from tbl_grade where active=true and id=@id order by from_score desc ";
                    var param = new { @id = id };
                    var results = connection.Query<Grade>(gradeQuery,param);
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
