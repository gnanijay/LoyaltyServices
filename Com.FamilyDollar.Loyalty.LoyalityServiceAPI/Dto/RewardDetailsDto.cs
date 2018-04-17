﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto
{
    /// <summary>
    /// Reward model class is usfull to map entity model REWARD to required formate the end clients.
    /// </summary>
    public class RewardDetailsDto
    {
        public long CId { get; set; }
        public long RewardId { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public long? CouponId { get; set; }
        public DateTime? CouponExpiryDate { get; set; }
        public string RewardType { get; set; }
        public string Status { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? RedeemDate { get; set; }
        public string CouponClipped { get; set; }
        public DateTime? CouponClipDate { get; set; }
        public DateTime? CouponDeclinedDate { get; set; }
        public string CouponDeclined { get; set; }

    }
}


