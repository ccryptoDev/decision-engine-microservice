using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DecisionEngine.Entities.Entity
{
    [Table("tbl_offer_grade")]
    public class OfferGrade
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("offer_value_id")]
        public long OfferValueId { get; set; }
        [Column("grade_id")]
        public long GradeId { get; set; }

        [Column("min_apr")]
        public double MinAPR { get; set; }
        [Column("max_apr")]
        public double MaxAPR { get; set; }

        [Column("avg_apr")]
        public double AvgAPR { get; set; }
        [Column("created_at")]
        public DateTime createdAt { get; set; }

        [Column("updated_at")]
        public DateTime modifiedAt { get; set; }
        public Boolean active { get; set; }
        [Column("setting_id")]
        public long SettingId { get; set; }
    }

    public class OfferGradeDetail
    {
        
        public long Id { get; set; }

      
        public long offer_value_id { get; set; }
        
        public long grade_id { get; set; }

        public string offer_label { get; set; }

        public string offer_value { get; set; }

        public string grade_description { get; set; }


        public double min_apr { get; set; }
       
        public double max_apr { get; set; }
        public long SettingId { get; set; }

        public double avg_apr { get; set; }
       
    }

    public class GradeAvgs
    {
        public long GradeId { get; set; }
        public double MinAPR { get; set; }

        public double MaxAPR { get; set; }
        public long SettingId { get; set; }

        public double AvgAPR { get; set; }
    }

   

    public class ResponseOfferValue
    {
        public long id { get; set; }
        public string offer_value { get; set; }

    }
}
