using Microsoft.Extensions.DependencyInjection;

namespace DecisionEngine.Services.Ioc
{
    public class TransUnionServiceDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ITransUnionService, TransUnionService>();
        }
    }
}
