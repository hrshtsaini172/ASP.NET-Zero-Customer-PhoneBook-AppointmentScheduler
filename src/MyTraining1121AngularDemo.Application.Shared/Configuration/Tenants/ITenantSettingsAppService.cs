using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Configuration.Tenants.Dto;

namespace MyTraining1121AngularDemo.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
