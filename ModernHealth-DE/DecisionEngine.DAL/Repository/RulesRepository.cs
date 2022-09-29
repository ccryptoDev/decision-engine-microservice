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
   public class RulesRepository : BaseRepository, IRulesRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
        public RulesRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
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
        public string InsertSettingRule(long setting_id)
        {

            try
            {
                if(_context.Rules.Where(d=>d.setting_id==setting_id).Count()>0)
                    return "This Settings already exist.";

                var settingRuleAcive = _context.Rules.Where(item => item.setting_id == 0 && item.disabled==false);

                foreach (var rule in settingRuleAcive)
                {
                    var ruleSetting = new Rule()
                    {
                          rule_id=rule.rule_id,
                           declinedif=rule.declinedif,
                            disabled=rule.disabled,
                             setting_id=setting_id,
                             passthru=rule.passthru,
                              value=rule.value,
                              createdAt=DateTime.UtcNow
                    };
                  
                    _context.Rules.Add(ruleSetting);
                }
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


        public string AddOrUpdateSettingRule(List<SettingRule> settingRules)
        {

            try
            {
                var settingRuleAcive = _context.SettingRules.Where(item => item.Id == settingRules[0].setting_id);
                foreach(SettingRule setting in settingRuleAcive)
                {
                    setting.active = false;
                    _context.SettingRules.Update(setting);
                }

                foreach (SettingRule settingRule in settingRules)
                {
                    SettingRule settingRuleDB = _context.SettingRules.FirstOrDefault(item => item.Id == settingRule.Id);
                   

                    _context.SettingRules.Add(settingRule);
                    if (settingRuleDB == null)
                    {
                        settingRule.active = true;
                        settingRule.createdAt = DateTime.UtcNow;
                        _context.SettingRules.Add(settingRule);
                    }
                    else
                    {
                        settingRuleDB.updatedAt = DateTime.UtcNow;
                        settingRuleDB.setting_id = settingRule.setting_id;
                        settingRuleDB.rule_id = settingRule.rule_id;
                        settingRuleDB.active = true;
                        _context.SettingRules.Update(settingRuleDB);
                    }
                }
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
        public List<SettingRulesResponse> GetLoadSettingRules(long setting_id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string rulesQuery = " select  a.id as rule_id, a.description ,coalesce(b.id, 0) id ,b.setting_id from tblRules_Description a join tbl_setting_Rules b "
                        + " on a.id = b.rule_id  where b.setting_id=@settingid order by a.id ";
                    var param = new { settingid = setting_id };
                    var results = connection.Query<SettingRulesResponse>(rulesQuery,param);
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
        public string UpdateRule(Rule rule)
        {

            try
            {
                Rule entity = _context.Rules.FirstOrDefault(item => item.Id == rule.Id);
                if (entity == null)
                {
                    rule.createdAt = DateTime.UtcNow;
                    _context.Rules.Add(rule);

                }
                else
                {
                    entity.disabled = rule.disabled;
                    entity.value = rule.value;
                    entity.declinedif = rule.declinedif;
                    entity.rule_id = rule.rule_id;
                    entity.setting_id = rule.setting_id;
                    entity.passthru = rule.passthru;
                    _context.Rules.Update(entity);
                   
                }
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


        public List<RulesResponse> GetLoadRules(long setting_id)
        {

            try
            {
                using (var connection = pgOpenConnection())
                {
                    if (_context.Rules.Where(d => d.setting_id == setting_id).Count() > 0)
                    {
                       

                        string rulesQuery = " select * from( select * from( select  a.id as rule_id, a.description ,coalesce(b.id, 0) id ,b.createdat, b.declinedif, b.value,b.disabled,b.setting_id,a.short_desc,b.passthru from "

             + " tblRules_Description a join tblRules b on a.id = b.rule_id where b.setting_id = @settingid and a.ruletype = 'T'  union select  a.id as rule_id, a.description ,coalesce(b.id, 0) id ,b.createdat, b.declinedif, b.value,"
            + "   b.disabled,b.setting_id,a.short_desc,b.passthru from tblRules_Description a left join tblRules b  on a.id = b.rule_id  and b.setting_id = 0  where a.ruletype = 'T' and a.id not in (select rule_id from tblrules "
            + " where setting_id = @settingid)) a order by cast(replace(short_desc, 'R', '') as integer))a "
               + " union all select *from(select * from(select  a.id as rule_id, a.description, coalesce(b.id, 0) id, b.createdat, b.declinedif, b.value, b.disabled, b.setting_id, a.short_desc,b.passthru from "
               + " tblRules_Description a join tblRules b on a.id = b.rule_id where b.setting_id = @settingid  and a.ruletype = 'B' union   select  a.id as rule_id, a.description, coalesce(b.id, 0) id, b.createdat, b.declinedif, b.value,"
               + "  b.disabled, b.setting_id, a.short_desc,b.passthru from tblRules_Description a left join tblRules b  on a.id = b.rule_id and b.setting_id = 0  where  a.ruletype = 'B' and a.id not in (select rule_id from tblrules where setting_id = @settingid)) a"
               + "  order by cast(replace(short_desc, 'BTR', '') as integer))a  ";
                        var param = new { settingid = setting_id };
                        var results = connection.Query<RulesResponse>(rulesQuery, param);
                        return results.ToList();
                    }
                    else
                        return new List<RulesResponse>();
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

                    string rulesQuery = " select  * from tblRules_Description a where not exists(select * from tblRules b where a.id=b.rule_id) and  active=true order by id";

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
        public string UpdateRuleDescription(RuleDescription ruleDescription)
        {

            try
            {
                RuleDescription entity = _context.RuleDescriptions.FirstOrDefault(item => item.Id == ruleDescription.Id);
                entity.description = ruleDescription.description;
                entity.active = ruleDescription.active;
                _context.RuleDescriptions.Update(entity);
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
        public List<RuleDescription> GetRuleDescriptions()
        {

            try
            {
                using (var connection = pgOpenConnection())
                {

                    string rulesQuery = " select * from tblRules_Description a  order by cast(replace(short_desc, 'R', '') as integer) ";
                      

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
