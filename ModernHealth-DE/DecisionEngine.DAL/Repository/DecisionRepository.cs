using Dapper;
using DecisionEngine.DAL.Interface;
using DecisionEngine.DAL.Repository.Rules;
using DecisionEngine.Entities.Context;
using DecisionEngine.Entities.Entity;
using DecisionEngine.Services.Models;
//using DecisionEngine.Entities.Entity;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DecisionEngine.DAL.Repository
{
    public class DecisionRepository : BaseRepository, IDecisionRepository
    {

        private readonly IConfiguration _configuration;
        private readonly DecisionEngineContext _context;
      
        public DecisionRepository(IConfiguration configuration, DecisionEngineContext context) : base(configuration)
        {
            _configuration = configuration;
            _context = context;
            
        }
        public async Task<LoanOffersResponse> GetApprovedOffers(LoanOffersRequest loanOffersRequest, DecisionEngine.Services.Models.Response.CreditReportResult creditReportResult)
        {
            try
            {
                if (creditReportResult == null)
                {
                    string json = File.ReadAllText("response_1630658125796.json");
                    creditReportResult = JsonConvert.DeserializeObject<DecisionEngine.Services.Models.Response.CreditReportResult>(json);
                }
                List<BankRule> bankRules = loanOffersRequest.bankRules;


                List<DecisionRules> rulesData = GetDecisionRules(loanOffersRequest.settingId,"T");
                Hashtable declined = new Hashtable();
                declined.Add("lt", "<"); //adding a key/value using the Add() method
                declined.Add("gt", ">");
                declined.Add("gte", ">=");
                declined.Add("lte", "<=");
                declined.Add("eq", "=");

                DateTime bankruptcystartdate, publicrecordstartdate, forclosurestartdate;
                DateTime enddate, inquirystartdate, tradestartdate, utilizationstartdate;

                bankruptcystartdate = DateTime.Now.AddMonths(-24);

                publicrecordstartdate = DateTime.Now.AddMonths(-24);
                enddate = DateTime.Now;
                inquirystartdate = DateTime.Now.AddMonths(-6);

                forclosurestartdate = DateTime.Now.AddMonths(-12);
                tradestartdate = DateTime.Now.AddDays(30);

                utilizationstartdate = DateTime.Now.AddMonths(-6);

                // var rectangle = new Rectangle(12, 9);
                var container = new RulesContainer();
                Dictionary<string, string> ruledatacount = new Dictionary<string, string>();

                // Add the shapes to the container.

                //  container.AddShape(rectangle);

                // Cause some events to be raised.
                // circle.Update(57);
                foreach (var rl in rulesData)
                {
                    string shortDesc = rl.shortdesc.ToLower();
                    string description = rl.description;
                    DateTime startdate, rule1startdate;
                    if (shortDesc == "r1")
                    {
                        int rule1val = rl.value;
                        startdate = DateTime.Now.AddMonths(-rule1val);

                        // Rules 1 startdate comes dynamically
                        rule1startdate = DateTime.Now.AddMonths(-rule1val);

                        var rule1 = new Rule1(rule1startdate, rl, creditReportResult, ruledatacount);
                        container.AddRule(rule1);

                    }
                    else if (shortDesc == "r2")
                    {
                        var rule2 = new Rule2(rl, creditReportResult, ruledatacount);
                        container.AddRule(rule2);

                    }
                    else if (shortDesc == "r3")
                    {
                        var rule3 = new Rule3(rl, creditReportResult, ruledatacount);
                        container.AddRule(rule3);

                    }
                    else if (shortDesc == "r4")
                    {
                        var rule4 = new Rule4(rl, inquirystartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule4);

                    }
                    else if (shortDesc == "r5")
                    {
                        var rule5 = new Rule5(rl, bankruptcystartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule5);

                    }
                    else if (shortDesc == "r6")
                    {
                        var rule6 = new Rule6(rl, forclosurestartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule6);

                    }
                    else if (shortDesc == "r7")
                    {
                        var rule7 = new Rule7(rl, publicrecordstartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule7);

                    }
                    else if (shortDesc == "r8")
                    {
                        var rule8 = new Rule8(rl, enddate, creditReportResult, ruledatacount);
                        container.AddRule(rule8);

                    }
                    else if (shortDesc == "r9")
                    {
                        var rule9 = new Rule9(rl, enddate, creditReportResult, ruledatacount);
                        container.AddRule(rule9);

                    }
                    else if (shortDesc == "r10")
                    {
                        var rule10 = new Rule10(rl, utilizationstartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule10);

                    }
                    else if (shortDesc == "r11")
                    {
                        var rule11 = new Rule11(rl, loanOffersRequest.CrediScore, ruledatacount);
                        container.AddRule(rule11);

                    }
                    else if (shortDesc == "r12")
                    {
                        var rule12 = new Rule12(rl,  creditReportResult, ruledatacount,loanOffersRequest.Income);
                        container.AddRule(rule12);

                    }
                    else
                    {
                        var rule10 = new Rule10(rl, utilizationstartdate, creditReportResult, ruledatacount);
                        container.AddRule(rule10);

                    }
                }
                List<string> passRules = new List<string>();
                List<string> failRules = new List<string>();

                // new System.Collections.Generic.ICollectionDebugView<DecisionEngine.DAL.Repository.Rules.Rules>(container._list).Items[0]
                var approveCnt = 0;
                var ruleCnt = container.ListRule().Count();
                foreach (DecisionEngine.DAL.Repository.Rules.Rules rule in container.ListRule())
                {
                    if (rule.RuleVal == 0)
                    {
                        approveCnt++;
                        passRules.Add(ruledatacount[rule.RuleId]);
                    }
                    else
                        failRules.Add(ruledatacount[rule.RuleId]);

                }
                string loanStatus = "Declined";
                if (approveCnt == ruleCnt)
                {
                    loanStatus = "Approved";
                }
                List<DecisionRules> bankDecisionRules = GetDecisionRules(loanOffersRequest.settingId,"B");
                // var rectangle = new Rectangle(12, 9);
                var bankContainer = new RulesContainer();
                Dictionary<string, string> bankRuledatacount = new Dictionary<string, string>();

                // Add the shapes to the container.

                //  container.AddShape(rectangle);

                // Cause some events to be raised.
                // circle.Update(57);
                foreach (var rl in bankDecisionRules)
                {
                        var rule1 = new BankRules(rl,bankRules, creditReportResult, bankRuledatacount);
                        bankContainer.AddRule(rule1);
                 
                }
                List<string> passBankRules = new List<string>();
                List<string> failBankRules = new List<string>();

                // new System.Collections.Generic.ICollectionDebugView<DecisionEngine.DAL.Repository.Rules.Rules>(container._list).Items[0]
               
                var ruleBankCnt = bankContainer.ListRule().Count();
                foreach (DecisionEngine.DAL.Repository.Rules.Rules rule in bankContainer.ListRule())
                {
                    if (rule.RuleVal == 0)
                    {
                        approveCnt++;
                        passBankRules.Add(bankRuledatacount[rule.RuleId]);
                    }
                    else
                        failBankRules.Add(bankRuledatacount[rule.RuleId]);

                }





                List<LoanOffer> loanOffers = new List<LoanOffer>();
                List<LoanTerm> termGrades = new List<LoanTerm>();
                List<ScoreApr> scoreAprs = new List<ScoreApr>();
                string RetrieveOffersWithDeclined = Convert.ToString(_configuration["Key:RetrieveOffersWithDeclined"]);
                if (RetrieveOffersWithDeclined == "true")
                {
                    var gradeAprs = GetGradeAndApr(loanOffersRequest.Income, loanOffersRequest.CrediScore, loanOffersRequest.settingId);
                    var ga = gradeAprs.FirstOrDefault();
                    if (ga == null)
                    {


                        var resultResponse = new LoanOffersResponse
                        {
                            Status = "Failed",
                            RulesCount = ruleCnt,
                            PassRules = passRules,
                            FailRules = failRules,
                            BankPassRules=passBankRules,
                            BankFailRules=failBankRules,
                            Aprs= scoreAprs,
                            Offers = loanOffers,
                            Terms = termGrades,
                          //  ApprovedUpTo = loanOffersRequest.Income,
                            Requestedloanamount = loanOffersRequest.Income,
                            Message = "Offers retrieved."/*,
                    creditReportResult=creditReportResult*/
                        };
                        return resultResponse;
                    }
                     scoreAprs = GetApr(loanOffersRequest.Income, loanOffersRequest.CrediScore, loanOffersRequest.settingId);
                  var  offerGrades = GetOfferGrades(ga.GradeId, loanOffersRequest.settingId);

                    termGrades = GetOfferTerms(ga.GradeId, loanOffersRequest.settingId);


                    foreach (var o in offerGrades)
                    {
                        loanOffers.Add(new LoanOffer
                        {
                            //Apr = ga.Apr,
                            FinalRequestedLoanAmount = loanOffersRequest.Income,
                            FinancedAmount = loanOffersRequest.Income,
                            FullNumberAmount = 0,
                            InterestFeeAmount = 0,
                            InterestRate = 0,
                            LoanAmount = loanOffersRequest.Income,
                            LoanGrade = o.grade_description,
                            MaxCreditScore = ga.MaxScore,
                            MaxDTI = 40,
                            MaximumAmount = ga.MaxIncome,
                            MinCreditSCore = ga.MinScore,
                            MinDTI = 30,
                            MinimumAmount = ga.MinIncome,
                            TotalLoanAmount = 0,
                            OfferType = o.offer_label,
                            OfferValue = o.offer_value,
                            FundingRate=o.min_apr,
                            SalesPrice=o.max_apr
                        });
                    }

                }
                var result = new LoanOffersResponse
                {
                    Status = loanStatus,
                    RulesCount = ruleCnt,
                    PassRules = passRules,
                    FailRules = failRules,
                    BankPassRules = passBankRules,
                    BankFailRules = failBankRules,
                    Aprs = scoreAprs,
                    Offers = loanOffers,
                    Terms = termGrades,
                   
                    Requestedloanamount = loanOffersRequest.Income,
                    Message = "Offers retrieved."/*,
                    creditReportResult=creditReportResult*/
                };


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateApproved(string id)
        {

            try
            {
                if (id != "")
                {
                    string _strWtConnection = _configuration.GetConnectionString("WelcomeConnection");

                    if (_strWtConnection != "")
                    {
                        NpgsqlConnection wtconn = new NpgsqlConnection(_strWtConnection);
                        if (wtconn.State == ConnectionState.Closed)
                        {
                            wtconn.Open();

                            string query = " UPDATE tblloan SET status_flag = 'approved'::tblloan_status_flag_enum::tblloan_status_flag_enum WHERE user_id='" + id + "'";
                            string queryUser = " UPDATE tbluser SET active_flag = 'Y'::tbluser_active_flag_enum::tbluser_active_flag_enum WHERE id='" + id + "'";

                            wtconn.Execute(query);
                            wtconn.Execute(queryUser);
                        }
                        wtconn.Close();
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
        private List<DecisionRules> GetDecisionRules(long settingId,string ruleType)
        {
            
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string replaceContent = "R";
                    if (ruleType == "B")
                        replaceContent = "BTR";

                    string query = " select r.rule_id,r.id prod_rule_id, r.declinedif,r.value,rd.description,rd.short_desc shortdesc from tblrules r, "
                        + " tblrules_description rd where r.rule_id = rd.id and rd.active = true and r.disabled = false and  coalesce(r.setting_id,0)=@settingId "
                        + " and rd.ruletype=@RuleType and rd.active = true and r.disabled = false  order by cast(replace(short_desc,@replaceContent,'') as integer)";
                    var param = new { settingId = settingId,RuleType = ruleType, replaceContent = replaceContent  };
                    return connection.Query<DecisionRules>(query, param).ToList();
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
        private List<ServiceCode> GetServiceCodes()
        {
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = " select * from tbl_servicecodes ";

                    return connection.Query<ServiceCode>(query).ToList();
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

        private List<ScoreApr> GetApr(long loanAmount, int crediScore,long settingId)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = " select ga.id,ga.grade_id GradeId, ga.apr, s.from_score as MinScore, s.to_score as MaxScore,ga.setting_id as SettingId " +
                                " from public.tbl_gradeapr ga   inner join public.tbl_score s on ga.score_id = s.id  " +
                                " where ga.active = true  and s.active = true and  @Score between s.from_score and s.to_score  and  coalesce(ga.setting_id,0)=@SettingId";

                    return connection.Query<ScoreApr>(query, new { Score = crediScore, Income = loanAmount ,SettingId=settingId}).ToList();
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
        private List<GradeApr> GetGradeAndApr(long loanAmount, int crediScore, long settingId)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = " select ga.id,ga.grade_id GradeId, ga.apr, s.from_score as MinScore, s.to_score as MaxScore,ic.min_income as MinIncome, ic.max_income as MaxIncome,s.offer_id as OfferId " +
                                " from public.tbl_gradeapr ga  inner join public.tbl_income ic on ga.income_id = ic.id inner join public.tbl_score s on ga.score_id = s.id  " +
                                " where ga.active = true and ic.active = true and s.active = true and  @Score between s.from_score and s.to_score  and  " +
                                " @Income between ic.min_income and ic.max_income  and  coalesce(ga.setting_id,0)=@SettingId";

                    return connection.Query<GradeApr>(query, new { Score = crediScore, Income = loanAmount, SettingId = settingId }).ToList();
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

        public List<OfferGradeDetail> GetOfferGrades(int grade, long settingId)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = " select o.offer_label,ov.offer_id,ov.offer_value,og.min_apr,og.max_apr,og.avg_apr,g.grade_description,og.grade_id,og.id "
                        + " from tbl_grade g, tbl_offer o, tbl_offer_value ov ,tbl_offer_grade og where g.id = og.grade_id and ov.id = og.offer_value_id and "
                        + " ov.offer_id = o.id and o.active = true and g.active = true and og.active = true and ov.active=true and g.id = @Grade  and  coalesce(og.setting_id,0)=@SettingId";


                    return connection.Query<OfferGradeDetail>(query, new { Grade = grade ,SettingId = settingId }).ToList();
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
        public List<LoanTerm> GetOfferTerms(int grade, long settingId)
        {
            try
            {
                using (var connection = pgOpenConnection())
                {
                    string query = " select g.grade_description GradeDescription,t.term_description TermDescription,"
                        + " term_duration TermDuration,avg_term_payment MonthlyPayment,max_term_payment MaxMonthlyPayment from tbl_grade g, tbl_term t, tbl_term_grade tg  "
                        + " where g.id = tg.grade_id  and tg.term_id = t.id and t.active = true and g.active = true and tg.active = true and g.id =@Grade  and coalesce(tg.setting_id,0)=@SettingId";

                    return connection.Query<LoanTerm>(query, new { Grade = grade, SettingId = settingId }).ToList();
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
