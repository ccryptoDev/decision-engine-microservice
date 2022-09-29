using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{


    [Table("tbl_offer_value")]
    public class OfferValue
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("offer_id")]
        public long OfferId { get; set; }
        [Column("offer_value")]
        public string Value { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }

    public class OfferValueDetail
    {
        
      
        public long Id { get; set; }

        public long OfferId { get; set; }
     
        public string Value { get; set; }
     
        public string OfferLabel { get; set; }

        public long SettingId { get; set; }
    }
}
