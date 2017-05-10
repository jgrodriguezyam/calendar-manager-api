using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using CalendarManager.IoC.Configs;
using CalendarManager.Mapper.Configs;
using CalendarManager.Sessions;

[assembly: OwinStartup(typeof(CalendarManager.Startup))]
namespace CalendarManager
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var configuration = new HttpConfiguration(GlobalConfiguration.Configuration.Routes);
            SwaggerConfig.Register(configuration);
            FilterConfig.Register(configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            appBuilder.UseCors(CorsOptions.AllowAll);
            appBuilder.UseWebApi(configuration);
            SimpleInjectorConfig.Register(configuration);
            GlobalConfiguration.Configuration.Filters.Add(new AuthorizeLogin());
            FastMapperConfig.Initialize();
        }
    }
}
