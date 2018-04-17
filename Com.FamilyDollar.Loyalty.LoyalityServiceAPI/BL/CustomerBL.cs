using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models;
using System.Linq;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.BL
{
    public class CustomerBL
    {
        public Dto.CustomerDto GetCustomerRewards(long id)
        {
            using (var dbContext = new LoyaltyDBContext())
            {
                var rewardTypes = dbContext.RewardTypes;
                var vCustomerRewards = dbContext.VCustomerRewards.FirstOrDefault(c => c.CId == id);
                if (vCustomerRewards == null)
                {
                    return null; // When customer id is invalid. return null;
                }
                var customerRewards = (from r in dbContext.Rewards.Where(r => r.CId == id && (r.Status.ToUpper() == "ACTIVE") || (r.Status.ToUpper() == "PENDING"))
                                       join rt in dbContext.RewardTypes on r.RewardTypeId equals rt.TypeId
                                       where r.CId == id
                                       select new Dto.RewardDto
                                       {
                                           CId = r.CId,
                                           RewardId = r.RewardId,
                                           CouponExpiryDate = r.CouponExpiryDate,
                                           CouponId = r.CouponId,
                                           ExpiryDate = r.ExpiryDate,
                                           Status = r.Status
                                       }).ToList();

                var customerDto = new Dto.CustomerDto
                {
                    CId = vCustomerRewards.CId,
                    PilotUser = vCustomerRewards.PilotUser,
                    TotalRewardCount = customerRewards.Count(),
                    Rewards = customerRewards
                };
                return customerDto;
            }
        }
    }
}