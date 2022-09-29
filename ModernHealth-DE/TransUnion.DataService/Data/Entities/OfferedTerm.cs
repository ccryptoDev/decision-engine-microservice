using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisionEngine.DataService.Data.Entities
{
    [Table("tbl_offered_term")]
    public  class OfferedTerm
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("term_name")]
        public string TermName { get; set; }

        [Column("monthly_payment")]
        public double MOnthlyPayment { get; set; }

        [Column("avg_monthly_payment")]
        public string AvgMonthlyPayment { get; set; }

        [Column("max_monthly_payment")]
        public string MaxMonthlyPayment { get; set; }
       
        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("loan_offer_id")]
        public string LoanOfferId { get; set; }

        public OfferLoanAmount OfferLoanAmount { get; set; }
    }
}
