using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Net.Emailing
{
    public interface IEmailSettingsChecker
    {
        bool EmailSettingsValid();

        Task<bool> EmailSettingsValidAsync();
    }
}