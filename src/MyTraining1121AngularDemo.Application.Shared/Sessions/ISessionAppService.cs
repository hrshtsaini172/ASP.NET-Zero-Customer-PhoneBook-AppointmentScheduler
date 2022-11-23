using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Sessions.Dto;

namespace MyTraining1121AngularDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
