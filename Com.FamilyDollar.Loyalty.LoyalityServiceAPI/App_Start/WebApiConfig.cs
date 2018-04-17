using Com.FamilyDollar.Loyalty.Common.Handlers;
using Com.FamilyDollar.Loyalty.Common.Loggers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace Com.FamilyDollar.Loyalty.LoyalityServiceAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Web API configuration and services
            config.Services.Replace(typeof(IExceptionLogger), new NLogExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

           // config.MessageHandlers.Add(new MessageHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }
    }
}
