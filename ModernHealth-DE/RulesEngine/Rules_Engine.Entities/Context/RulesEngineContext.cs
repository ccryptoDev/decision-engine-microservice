using Microsoft.EntityFrameworkCore;
using Rules_Engine.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rules_Engine.Entities.Context
{
   public class RulesEngineContext : DbContext
    {
        public RulesEngineContext(DbContextOptions<RulesEngineContext> options) : base(options)
        {

        }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<GradeAPR> GradeAPRs { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Income> Incomes { get; set; }

        public DbSet<OfferLoan> OfferLoans { get; set; }
        public DbSet<OfferedTerm> OfferedTerms { get; set; }
        public DbSet<RuleDescription> RuleDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
