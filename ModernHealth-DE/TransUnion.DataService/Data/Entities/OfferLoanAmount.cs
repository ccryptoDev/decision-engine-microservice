using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DecisionEngine.DataService.Data.Entities
{
    [Table("tbl_offer_loan_amount")]
    public class OfferLoanAmount
    {
        public OfferLoanAmount()
        {
            OfferedTerms = new List<OfferedTerm>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("offer_name")]
        public string OfferName { get; set; }

        [Column("aount")]
        public double Amount { get; set; }

        [Column("grade")]
        public string Grade { get; set; }

        [Column("active")]
        public bool Active { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        public List<OfferedTerm> OfferedTerms { get; set; }
    }
}
