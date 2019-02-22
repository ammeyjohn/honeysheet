using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;

namespace HoneySheet.Api
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Api");
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }
    }
}
