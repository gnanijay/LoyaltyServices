using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [Table("FDV_CUSTOMER_REWARDS")]
    public class VCustomerRewards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CId { get; set; }
        public char PilotUser { get; set; }
        public int? TotalRewardCount { get; set; }
    }
}




