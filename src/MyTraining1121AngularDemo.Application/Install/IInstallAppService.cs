using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Install.Dto;

namespace MyTraining1121AngularDemo.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}