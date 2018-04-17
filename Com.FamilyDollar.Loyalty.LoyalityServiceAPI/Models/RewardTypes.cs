using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [Table("REWARD_TYPE")]
    public class RewardType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TypeId { get; set; }
        public string Type { get; set; }
        public string Active { get; set; }
        public string SendPush { get; set; }
        public string DefaultPushMessage { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Created { get; set; }
       

    }
}

