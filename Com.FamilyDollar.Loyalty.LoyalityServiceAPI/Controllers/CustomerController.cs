using Com.FamilyDollar.Loyalty.Common.Filters;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.BL;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Common;
using Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Dto;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Controllers
{
    [Route("api/Customer/{id}/rewards")]
    [ExceptionFilters]
    public class CustomerController : ApiController
    {
        LogBL logBL = new LogBL();
        CustomerBL customerBL = new CustomerBL();
        #region Public rest methods
        public HttpResponseMessage GetCustomerRewards(long id)
        {
            CustomerDto customerDto = customerBL.GetCustomerRewards(id);
            HttpResponseMessage response = null;
            if (customerDto == null)
            {
                var customerStatus = HttpHelper.GetCustomHttpStatusCode("CUSTOMER_GET_FAILED");
                logBL.Log(customerStatus, id);
                response = Request.CreateResponse(HttpStatusCode.BadRequest, customerStatus);
            }
            else if (customerDto.Rewards.Count == 0)
            {
                var rewardsStatus = HttpHelper.GetCustomHttpStatusCode("CUSTOMER_REWARDS_GET_FAILED");
                logBL.Log(rewardsStatus, id);
                response = Request.CreateResponse(HttpStatusCode.OK, rewardsStatus);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, customerDto);
            }
            return response;
        }
        #endregion Public rest methods
    }
}
