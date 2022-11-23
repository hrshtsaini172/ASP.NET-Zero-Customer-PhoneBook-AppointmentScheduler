using System.Threading.Tasks;
using Abp.Application.Services;

namespace MyTraining1121AngularDemo.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
