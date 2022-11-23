using System.Threading.Tasks;
using Abp.Domain.Policies;

namespace MyTraining1121AngularDemo.Authorization.Users
{
    public interface IUserPolicy : IPolicy
    {
        Task CheckMaxUserCountAsync(int tenantId);
    }
}
