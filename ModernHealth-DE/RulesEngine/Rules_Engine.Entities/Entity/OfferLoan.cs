using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rules_Engine.Entities.Entity
{
  
    [Table("tbl_offer_loan_amount")]
    public class OfferLoan
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("offer_name")]
        public string OfferName { get; set; }
        [Column("amount")]
        public double Amount { get; set; }

        [Column("grade")]
        public string Grade { get; set; }

        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
    }
}
