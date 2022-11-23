using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using MyTraining1121AngularDemo.Configuration.Dto;

namespace MyTraining1121AngularDemo.Configuration
{
    public interface IUiCustomizationSettingsAppService : IApplicationService
    {
        Task<List<ThemeSettingsDto>> GetUiManagementSettings();

        Task UpdateUiManagementSettings(ThemeSettingsDto settings);

        Task UpdateDefaultUiManagementSettings(ThemeSettingsDto settings);

        Task UseSystemDefaultSettings();

        Task ChangeDarkModeOfCurrentTheme(bool isDarkModeActive);
    }
}
