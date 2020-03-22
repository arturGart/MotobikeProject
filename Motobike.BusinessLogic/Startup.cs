using Microsoft.Extensions.DependencyInjection;
using Motobike.BusinessLogic.Services;
using Motobike.BusinessLogic.Services.Interface;

namespace Motobike.BusinessLogic
{
    public class Startup
    {
        public static void Configure(IServiceCollection services)
        {
            RegisterServicesDependencies(services);
        }

        public static void RegisterServicesDependencies(IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
