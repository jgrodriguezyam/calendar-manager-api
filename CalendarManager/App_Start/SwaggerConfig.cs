using System.Web.Http;
using Swashbuckle.Application;
using CalendarManager.Filters;

namespace CalendarManager
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration configuration)
        {
            configuration
                .EnableSwagger(configure =>
                {
                    configure.SingleApiVersion("v1", "CalendarManager");
                    configure.OperationFilter<SwaggerOperationFilter>();
                })
                .EnableSwaggerUi();
        }
    }
}