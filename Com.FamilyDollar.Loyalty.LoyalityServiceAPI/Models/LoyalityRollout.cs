using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [Table("LOYALTY_ROLLOUT")]
    public class LoyalityRollout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CId { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
    }
}


