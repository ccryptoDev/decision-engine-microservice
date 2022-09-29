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
    public class TermRepository : BaseRepository, ITermRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public TermRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public CreateResponse CreateTerm(Term term)
        {
            CreateResponse createResponse = new CreateResponse();
            try
            {
                term.createdAt = DateTime.UtcNow;
                term.active = true;
                _context.Terms.Add(term);
                _context.SaveChanges();
                createResponse.id = term.Id;
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
        public string UpdateTerm(Term term)
        {

            try
            {
                Term entity = _context.Terms.FirstOrDefault(item => item.Id == term.Id);

                entity.description = term.description;
                entity.SettingId = term.SettingId;
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

        public string DeleteTerm(int id)
        {

            try
            {
                Term entity = _context.Terms.FirstOrDefault(item => item.Id == id);
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

        public List<TermDtl> GetTerms(long settingId)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string termQuery = " select id,term_description description,setting_id as SettingId from tbl_term where active=true and coalesce(setting_id,0)=@settingId order by description asc ";

                    var results = connection.Query<TermDtl>(termQuery, new { settingId = settingId });
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
        public TermDtl LoadTermById(int id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string termQuery = " select id,term_description description,setting_id as SettingId from tbl_term where active=true  and id=@id order by description asc";
                    var param = new { @id = id };
                    var results = connection.Query<TermDtl>(termQuery, param);
                    var offerValue = results.FirstOrDefault();
                    if (offerValue == null)
                        return new TermDtl();
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
