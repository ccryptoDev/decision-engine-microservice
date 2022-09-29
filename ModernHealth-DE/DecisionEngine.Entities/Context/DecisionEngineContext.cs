
using DecisionEngine.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.Entities.Context
{
   public class DecisionEngineContext : DbContext
    {
        public DecisionEngineContext(DbContextOptions<DecisionEngineContext> options) : base(options)
        {

        }
        public DbSet<TermGrade> TermGrades { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<OfferGrade> OfferGrades { get; set; }
        public DbSet<OfferValue> OfferValues { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<GradeAPR> GradeAPRs { get; set; }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<SettingRule> SettingRules { get; set; }
        public DbSet<RuleDescription> RuleDescriptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
