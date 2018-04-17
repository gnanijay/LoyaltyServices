using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models
{
    [Table("REWARD")]
    public class Reward
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long RewardId { get; set; }

        [Required]
        public long CId { get; set; }
        public int RewardTypeId { get; set; }

        [Required]
        public string TriggerType { get; set; }

        public string TriggerData { get; set; }

        public long TriggerId { get; set; }
        public Nullable<long> CouponId { get; set; }
        public Nullable<System.DateTime> CouponExpiryDate { get; set; }
        public string CouponDenied { get; set; }

        public DateTime? CouponDeclinedDate { get; set; }

        //[Required]
        public string Status { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<System.DateTime> RedeemDate { get; set; }
        public string DeviceId { get; set; }

       // [Required]
        public decimal? GeoLat { get; set; }
       // [Required]
        public decimal? GeoLong { get; set; }
        public DateTime? LastPushSent { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? Created { get; set; }

        [Required]
        public DateTime TDate { get; set; }

        public virtual Customer Customer { get; set; }

        [NotMapped]
        public int? MaxRewardsCount { get; set; }

        public DateTime? CouponClipDate { get; set; }
    }
}