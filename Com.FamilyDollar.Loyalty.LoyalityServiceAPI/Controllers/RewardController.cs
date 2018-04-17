using Com.FamilyDollar.Loyalty.Common.Filters;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.BL;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Common;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Controllers
{
    [Route("api/reward/{id}")]
    [ExceptionFilters]
    public class RewardController : ApiController
    {
        RewardBL rewardBL = new RewardBL();
        LogBL logBL = new LogBL();
        public HttpResponseMessage GetReward(long id = 0)
        {
            RewardDetailsDto rewardDto = rewardBL.GetRewardDto(id);
            HttpResponseMessage response = null;
            if (rewardDto == null)
            {
                var failStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_GET_FAILED");
                logBL.Log(failStatus, null, id);
                response = Request.CreateResponse(HttpStatusCode.NotFound, failStatus);
            }
            else if (rewardDto.Status.Trim().ToUpper() == "EXPIRED")
            {
                var failStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_EXPIRED");
                logBL.Log(failStatus, null, id);
                response = Request.CreateResponse(HttpStatusCode.NotFound, failStatus);
            }
            else if (rewardDto.Status.Trim().ToUpper() == "REDEEMED")
            {
                var failStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_ALREADY_REDEEMED");
                logBL.Log(failStatus, null, id);
                response = Request.CreateResponse(HttpStatusCode.NotFound, failStatus);
            }
            else
            {
                var successStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_GET_SUCCESS");
                logBL.Log(successStatus, rewardDto.CId, rewardDto.RewardId);
                response = Request.CreateResponse(HttpStatusCode.OK, rewardDto);
            }
            return response;
        }

        [HttpPut]
        public HttpResponseMessage UpdateReward(long id, [FromBody]UpdateRewardDto rewardDto)
        {
            RewardBL rewardBL = new RewardBL();
            LogBL logBL = new LogBL();
            HttpResponseMessage response = null;
            var rDto = rewardBL.GetRewardDto(id);
            if (rDto != null)
            {
                if (IsRewardActive(rDto))
                {
                    rewardBL.UpdateReward(rewardDto);
                    var successStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_UPDATE_SUCCESS");
                    logBL.Log(successStatus, rewardDto.CId, rewardDto.RewardId);
                    response = Request.CreateResponse(HttpStatusCode.OK, successStatus);
                }
                else
                {
                    var failStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_UPDATE_FAILED");
                    string reason = string.Format("reward with reward id:{0} is expired", id);
                    logBL.Log(failStatus, rewardDto.CId, rewardDto.RewardId);
                    response = Request.CreateResponse(HttpStatusCode.BadRequest, failStatus);
                }
            }
            else
            {
                var failStatus = HttpHelper.GetCustomHttpStatusCode("REWARD_UPDATE_FAILED");
                string reason = string.Format("reward with reward id:{0} not found", id);
                logBL.Log(failStatus, rewardDto.CId, rewardDto.RewardId);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, failStatus);
            }
            return response;
        }

        private  bool IsRewardActive(RewardDetailsDto rDto)
        {
            return rDto.Status.Trim().ToUpper() == "ACTIVE" ||
                                rDto.Status.Trim().ToUpper() == "PENDING" ||
                                rDto.Status.Trim().ToUpper() == "REDEEMED";
        }
    }
}
