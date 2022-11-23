using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Configuration.Host.Dto;

namespace MyTraining1121AngularDemo.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
