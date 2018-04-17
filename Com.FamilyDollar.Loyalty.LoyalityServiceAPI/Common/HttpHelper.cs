using System.Collections.Specialized;
using System.Configuration;
using System.Linq;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI.Common
{
    public static class HttpHelper
    {
        public static CustomHttpStatusCode GetCustomHttpStatusCode(string key)
        {
            var httpStatusCode = new CustomHttpStatusCode();
            var appSettings = ConfigurationManager.GetSection("CustomErrorGroup/errorcodes") as NameValueCollection;
            string appsetting = string.Empty;
            if (appSettings[key] != null)
            {
                appsetting = appSettings[key].ToString();
            }
            else
            {
                appsetting = appSettings["UNKNOWN_ERROR"].ToString();
            }
            string[] codeMessage = appsetting.Split(',');
            httpStatusCode.Code = codeMessage[0];
            if (codeMessage.Count() >= 1)
            {
                httpStatusCode.Code = codeMessage[0];
                httpStatusCode.Message = codeMessage[1];
            }
            return httpStatusCode;
        }
    }
    public class CustomHttpStatusCode
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}