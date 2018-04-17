using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models.LogDB
{
    [Table("ACTIVITY_LOG")]
    public class ActivityLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long ActivityId { get; set; }
        public long? CId { get; set; }
        public long RewardId { get; set; }
        public long? TriggerId { get; set; }
        public string ErrorFlag { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Activity { get; set; }
    }
}

