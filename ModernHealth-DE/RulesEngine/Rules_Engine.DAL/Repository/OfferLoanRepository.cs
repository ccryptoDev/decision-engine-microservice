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
    public class OfferLoanRepository : BaseRepository, IOfferLoanRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public OfferLoanRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateOfferLoan(OfferLoan income)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                income.createdAt = DateTime.UtcNow;
                income.active = true;
                _context.OfferLoans.Add(income);
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
        public string UpdateOfferLoan(OfferLoan income)
        {

            try
            {
                OfferLoan entity = _context.OfferLoans.FirstOrDefault(item => item.Id == income.Id);

                entity.Amount = income.Amount;
                entity.Grade = income.Grade;
                entity.OfferName = income.OfferName;
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

        public string DeleteOfferLoan(int id)
        {

            try
            {
                OfferLoan entity = _context.OfferLoans.FirstOrDefault(item => item.Id == id);
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

        public List<OfferLoan> GetOfferLoans()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = " select id,offer_name as OfferName,"
                        + " amount as Amount, grade as Grade from tbl_offer_loan_amount where active=true order by offer_name ";

                    var results = connection.Query<OfferLoan>(incomeQuery);
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

        public OfferLoan LoadOfferLoanById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = " select id,offer_name as OfferName,"
                        + " amount as Amount,grade as Grade from tbl_offer_loan_amount where active=true and id=@id";
                    var param = new { @id = id };
                    var results = connection.Query<OfferLoan>(incomeQuery, param);
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

        public List<OfferLoanResult> GetOfferLoanWithTerms(string grade = null)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = string.Empty;

                    if (string.IsNullOrEmpty(grade))
                    {
                        query = "select ola.id,ola.grade,ola.offer_name as OfferName,ola.amount as Amount,ot.term_name as TermName, " +
                                " ot.offered_term as TermValue, ot.avg_monthly_payment as AvgMonthlyPayment, ot.max_monthly_payment as MaxMonthlyPayment " +
                                " from public.tbl_offer_loan_amount ola inner join public.tbl_offered_term ot on ola.id= ot.loan_offer_id " +
                                " where ola.active = true and ot.active = true";

                        return connection.Query<OfferLoanResult>(query).ToList();
                    }
                    else
                    {
                        query = "select ola.id,ola.grade,ola.offer_name as OfferName,ola.amount as Amount,ot.term_name as TermName, " +
                                " ot.offered_term as TermValue, ot.avg_monthly_payment as AvgMonthlyPayment, ot.max_monthly_payment as MaxMonthlyPayment " +
                                " from public.tbl_offer_loan_amount ola inner join public.tbl_offered_term ot on ola.id= ot.loan_offer_id " +
                                " where ola.active = true and ot.active = true and ola.grade = @Grade";

                        return connection.Query<OfferLoanResult>(query, new { @Grade = grade }).ToList();
                    }
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
