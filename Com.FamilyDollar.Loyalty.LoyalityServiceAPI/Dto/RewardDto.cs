using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto
{
    public class RewardDto
    {
        public long CId { get; set; }
        public long RewardId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? CouponId { get; set; }
        public DateTime? CouponExpiryDate { get; set; }
        public string Status { get; set; }
    }
}


