using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto
{
    /// <summary>
    /// Customer model class is usfull to map entity model CUSTOMER to required formate the end clients.
    /// </summary>
    public class CustomerDto
    {
        public long CId { get; set; }
        public long? TotalRewardCount { get; set; }
        public char PilotUser { get; set; }
        public List<RewardDto> Rewards { get; set; }
    }
}

