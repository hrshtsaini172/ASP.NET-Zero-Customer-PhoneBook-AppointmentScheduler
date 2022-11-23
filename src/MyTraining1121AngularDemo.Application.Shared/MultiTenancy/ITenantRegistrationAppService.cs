using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Editions.Dto;
using MyTraining1121AngularDemo.MultiTenancy.Dto;

namespace MyTraining1121AngularDemo.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}