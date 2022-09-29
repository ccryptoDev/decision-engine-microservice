using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
    [Table("tbl_score")]
    public class Score
    {
            [Key]
            [Column("id")]
            public long Id { get; set; }
            [Column("from_score")]
            public long FromScore { get; set; }

            // public string? description { get; set; }
            [Column("to_score")]
            public long ToScore { get; set; }
        [Column("offer_id")]
        public long? offerId { get; set; }

        [NotMapped]
        public string offerLabel { get; set; }

        [Column("created_at")]
            public DateTime createdAt { get; set; }

            [Column("updated_at")]
            public DateTime modifiedAt { get; set; }

            public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }
    public class CreateResponse
    {
        public string message { get; set; }
        public string status { get; set; }
        public long id { get; set; }
              public long SettingId { get; set; }
    }
}
