using Microsoft.Extensions.DependencyInjection;
using MyTraining1121AngularDemo.HealthChecks;

namespace MyTraining1121AngularDemo.Web.HealthCheck
{
    public static class AbpZeroHealthCheck
    {
        public static IHealthChecksBuilder AddAbpZeroHealthCheck(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<MyTraining1121AngularDemoDbContextHealthCheck>("Database Connection");
            builder.AddCheck<MyTraining1121AngularDemoDbContextUsersHealthCheck>("Database Connection with user check");
            builder.AddCheck<CacheHealthCheck>("Cache");

            // add your custom health checks here
            // builder.AddCheck<MyCustomHealthCheck>("my health check");

            return builder;
        }
    }
}
