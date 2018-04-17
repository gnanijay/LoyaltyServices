using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public long CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? LastAccessedDate { get; set; }
        public DateTime? LastPushDate { get; set; }
        public DateTime? LastRewardDate { get; set; }
        public string AccountStatus { get; set; }
        public int? RewardSavings { get; set; }
        public int? CouponSavings { get; set; }
        public long? TotalRewardCount { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public decimal? GeoLat { get; set; }
        public decimal? GeoLong { get; set; }
        public string InmarToken { get; set; }
        public string UserToken { get; set; }
        public string IsAssociate { get; set; }
        public string AppVersion { get; set; }
        public string AppOs { get; set; }
        public string PushFlag { get; set; }
        public string LegalHold { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Created { get; set; }

        [ForeignKey("CId")]
        public List<Reward> Rewards { get; set; }
    }
}