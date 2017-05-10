using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Serialization;
using CalendarManager.Helpers;

namespace CalendarManager
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            configuration.MapHttpAttributeRoutes();
            configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();
            configuration.ParameterBindingRules.Add(descriptor => new CustomParameterBinding(descriptor));
        }
    }
}
