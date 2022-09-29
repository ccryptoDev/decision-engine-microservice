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
   public class IncomeRepository : BaseRepository, IIncomeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public IncomeRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateIncome(Income income)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                income.createdAt = DateTime.UtcNow;
                income.active = true;
                _context.Incomes.Add(income);
                _context.SaveChanges();
                createResponse.id = income.Id;
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
        public string UpdateIncome(Income income)
        {

            try
            {
                Income entity = _context.Incomes.FirstOrDefault(item => item.Id == income.Id);
                
                entity.MinIncome = income.MinIncome;
                entity.MaxIncome = income.MaxIncome;
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

        public string DeleteIncome(int id)
        {

            try
            {
                Income entity = _context.Incomes.FirstOrDefault(item => item.Id == id);
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

        public List<Income> GetIncomes()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = " select id,min_income as MinIncome,"
                        + " max_income as MaxIncome from tbl_income where active=true order by max_income desc ";

                    var results = connection.Query<Income>(incomeQuery);
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
        public Income LoadIncomeById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = " select id,min_income as MinIncome,"
                        + " max_income as MaxIncome from tbl_income where active=true and id=@id order by max_income desc ";
                    var param = new { @id = id };
                    var results = connection.Query<Income>(incomeQuery, param);
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
