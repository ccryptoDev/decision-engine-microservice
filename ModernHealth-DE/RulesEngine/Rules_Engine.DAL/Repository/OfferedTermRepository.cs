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
    public class OfferedTermRepository : BaseRepository, IOfferedTermRepository
    {
        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public OfferedTermRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public CreateResponse CreateOfferTerm(OfferedTerm request)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                request.createdAt = DateTime.UtcNow;
                request.active = true;
                _context.OfferedTerms.Add(request);
                _context.SaveChanges();
                createResponse.id = request.Id;
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

        public string DeleteOfferedTerm(int id)
        {
            try
            {
                var entity = _context.OfferedTerms.FirstOrDefault(item => item.Id == id);
                entity.active = false;
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

        public List<OfferedTerm> GetOfferTerms(int offerLoanId)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = "select id,term_name as TermName, offered_term as TermValue, avg_monthly_payment as AvgMonthlyPayment, " +
                                         " max_monthly_payment as MaxMonthlyPayment, loan_offer_id as LoanOfferId from public.tbl_offered_term where active =true and loan_offer_id = @id";
                   
                    var param = new { @id = offerLoanId };
                    var results = connection.Query<OfferedTerm>(incomeQuery, param);
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


        public OfferedTerm LoadOfferedTermById(int id)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {

                    string incomeQuery = "select id,term_name as TermName, offered_term as TermValue, avg_monthly_payment as AvgMonthlyPayment, " +
                                         " max_monthly_payment as MaxMonthlyPayment, loan_offer_id as LoanOfferId from public.tbl_offered_term where active =true and id = @id";
                    var param = new { @id = id };
                    var results = connection.Query<OfferedTerm>(incomeQuery, param);
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

        public string UpdateOfferedTerm(OfferedTerm request)
        {
            try
            {
                var entity = _context.OfferedTerms.FirstOrDefault(item => item.Id == request.Id);

                entity.TermName = request.TermName;
                entity.TermValue = request.TermValue;
                entity.AvgMonthlyPayment = request.AvgMonthlyPayment;
                entity.MaxMonthlyPayment = request.MaxMonthlyPayment;
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
    }
}

