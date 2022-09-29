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
   public class IncomeRepository : BaseRepository, IIncomeRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public IncomeRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
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
                entity.SettingId = income.SettingId;
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

        public List<Income> GetIncomes(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = " select id,min_income as MinIncome,"
                        + " max_income as MaxIncome,setting_id as SettingId from tbl_income where active=true  and coalesce(setting_id,0)=@settingId  order by max_income desc ";

                    var results = connection.Query<Income>(incomeQuery, new { settingId = settingId });
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
                        + " max_income as MaxIncome,setting_id as SettingId from tbl_income where active=true and id=@id order by max_income desc ";
                    var param = new { @id = id };
                    var results = connection.Query<Income>(incomeQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new Income();
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
