using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Common;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models.LogDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.BL
{
    public class LogBL
    {
        public bool isActivityLogEnable { get; set; }
        public LogBL()
        {
            var appsetting = ConfigurationManager.AppSettings["IsActivityLogEnable"];
            if (!string.IsNullOrEmpty(appsetting))
            {
                isActivityLogEnable = Convert.ToBoolean(appsetting);
            }
        }


        public void  Log(CustomHttpStatusCode status, long? customerId=0, long rewardId=0)
        {
            if (isActivityLogEnable)
            {
                using (var logDBContext = new LogDBContext())
                {
                    try
                    {
                        var activityLog = new ActivityLog();
                        activityLog.RewardId = rewardId;
                        activityLog.CId = customerId;
                        activityLog.ActivityDate = DateTime.Now;
                        activityLog.Activity = JsonConvert.SerializeObject(status);
                        logDBContext.ActivityLogs.Add(activityLog);
                        logDBContext.SaveChangesAsync();
                    }
                    catch (Exception)
                    {
                        // instead of throwing the exception, retuning. because logging is secondary activity.
                    }
                }
            }
        }
    }
}