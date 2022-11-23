using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MyTraining1121AngularDemo.EntityFrameworkCore;

namespace MyTraining1121AngularDemo.HealthChecks
{
    public class MyTraining1121AngularDemoDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public MyTraining1121AngularDemoDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("MyTraining1121AngularDemoDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("MyTraining1121AngularDemoDbContext could not connect to database"));
        }
    }
}
