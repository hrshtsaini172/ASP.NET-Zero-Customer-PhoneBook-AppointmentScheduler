using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Security
{
    public interface IPasswordComplexitySettingStore
    {
        Task<PasswordComplexitySetting> GetSettingsAsync();
    }
}
