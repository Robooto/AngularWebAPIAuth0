using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Configuration;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using ShipmentsAPI.App_Start;

namespace ShipmentsAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,  // client id
                SymmetricKey = clientSecret   // client secret
            });

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional});

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}