using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Rules_Engine.Entities.Entity
{

    [Table("tbl_offered_term")]
    public class OfferedTerm
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("term_name")]
        public string TermName { get; set; }    

        [Column("offered_term")]
        public int TermValue { get; set; }

        [Column("avg_monthly_payment")]
        public double AvgMonthlyPayment { get; set; }

        [Column("max_monthly_payment")]
        public double MaxMonthlyPayment { get; set; }

        [Column("loan_offer_id")]
        public int LoanOfferId { get; set; }


        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime? modifiedAt { get; set; }
        public Boolean active { get; set; }
    }
}
