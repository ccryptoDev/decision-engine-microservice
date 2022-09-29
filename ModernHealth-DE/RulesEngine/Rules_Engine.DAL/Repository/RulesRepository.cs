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
   public class RulesRepository : BaseRepository, IRulesRepository
    {

        private readonly IConfiguration _configuration;
        private readonly RulesEngineContext _context;
        public RulesRepository(IConfiguration configuration, RulesEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
        }
        public string CreateRule(Rule rule)
        {

            try
            {
                rule.createdAt = DateTime.UtcNow;
                _context.Rules.Add(rule);
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
        public string UpdateRule(Rule rule)
        {

            try
            {
                Rule entity = _context.Rules.FirstOrDefault(item => item.Id == rule.Id);
                entity.disabled = rule.disabled;
                entity.value = rule.value;
                entity.declinedif = rule.declinedif;
                entity.rule_id = rule.rule_id;
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
        public string CreateRuleDescription(RuleDescription ruleDescription)
        {

            try
            {

                _context.RuleDescriptions.Add(ruleDescription);
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


        public List<RulesResponse> GetLoadRules()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string rulesQuery = " select  a.id as rule_id, a.description ,coalesce(b.id, 0) id ,b.createdat, b.declinedif, b.value,b.disabled from tblRules_Description a join tblRules b "
                        + " on a.id = b.rule_id  order by a.description ";

                    var results = connection.Query<RulesResponse>(rulesQuery);
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

        public List<RuleDescription> GetLoadRuleDescription()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string rulesQuery = " select  * from tblRules_Description a where active=true";

                    var results = connection.Query<RuleDescription>(rulesQuery);
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
    }
}
