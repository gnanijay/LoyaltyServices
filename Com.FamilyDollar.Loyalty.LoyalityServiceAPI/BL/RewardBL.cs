using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Models;
using System;
using System.Linq;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.BL
{
    public class RewardBL
    {
        public Dto.RewardDetailsDto GetRewardDto(long id)
        {
            using (var dbContext = new LoyaltyDBContext())
            {
                var reward = dbContext.Rewards.FirstOrDefault(r => r.RewardId == id);
                if (reward == null)
                {
                    return null;
                }
                var rewardType = dbContext.RewardTypes.FirstOrDefault(r => r.TypeId == reward.RewardTypeId);

                if (!string.IsNullOrEmpty(reward.Status) && reward.Status.Trim().ToUpper() == "ACTIVE")
                {
                    // -Make a call to Optimove API to get user specific coupon (send the user/trigger data as parameter) 
                    // -Add the coupon details to couponid, coupon expiry date etc. 
                    //-Change the status of the reward to PENDING
                    reward.Status = "PENDING ";
                    dbContext.SaveChanges();
                }
                var rewardsDto = new Dto.RewardDetailsDto
                {
                    CId = reward.CId,
                    RewardId = reward.RewardId,
                    RewardType = rewardType.Type,
                    Status = reward.Status,
                    IssueDate = reward.IssueDate,
                    ExpiryDate = reward.ExpiryDate,
                    RedeemDate = reward.RedeemDate,
                    CouponId = reward.CouponId,
                    CouponExpiryDate = reward.CouponExpiryDate,
                    CouponClipped = reward.CouponClipDate != null ? "Y" : "N",
                    CouponClipDate = reward.CouponClipDate,
                    CouponDeclinedDate = reward.CouponDeclinedDate,
                    CouponDeclined = reward.CouponDeclinedDate != null ? "Y" : "N"
                };
                return rewardsDto;
            }
        }

        public bool UpdateReward(Dto.UpdateRewardDto rewardDto)
        {
            using (var dbContext = new LoyaltyDBContext())
            {
                var reward = dbContext.Rewards.FirstOrDefault(r => r.RewardId == rewardDto.RewardId); // it can be active or pending or redeemed or not expired
                //reward status should be active or pending 
                if (reward != null)
                {
                    if (!string.IsNullOrEmpty(rewardDto.Redeemed) && rewardDto.Redeemed.ToUpper() == "Y")
                    {
                        reward.RedeemDate = DateTime.Now;
                        reward.Status = "REDEEMED";
                    }
                    if (!string.IsNullOrEmpty(rewardDto.CouponClipped) && rewardDto.CouponClipped.ToUpper() == "Y")
                    {
                        reward.CouponClipDate = DateTime.Now;
                        reward.CouponDenied = "N";
                        reward.Status = "REDEEMED";
                    }

                    if (!string.IsNullOrEmpty(rewardDto.CouponDeclined) && rewardDto.CouponDeclined.ToUpper() == "Y")
                    {
                        reward.CouponDeclinedDate = DateTime.Now;
                        reward.CouponDenied = "Y";
                       // reward.CouponClipped
                        reward.Status = "REDEEMED";
                       // reward.RedeemedDeviceId
                    }
                    reward.GeoLat = rewardDto.GeoLat;
                    reward.GeoLong = rewardDto.GeoLong;
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
        }

    }
}