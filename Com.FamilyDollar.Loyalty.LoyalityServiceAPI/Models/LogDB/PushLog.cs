using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models.LogDB
{
    public class PushLog
    {
        public int PushId { get; set; }
        public int RewardId { get; set; }
        public int CId { get; set; }
        public DateTime SendDate { get; set; }
        public string DeviceId { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public string MessageId { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }

    }
}

