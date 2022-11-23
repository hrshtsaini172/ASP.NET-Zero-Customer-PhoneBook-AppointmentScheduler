using System.Threading.Tasks;
using MyTraining1121AngularDemo.ApiClient.Models;

namespace MyTraining1121AngularDemo.Services.Account
{
    public interface IAccountService
    {
        AbpAuthenticateModel AbpAuthenticateModel { get; set; }
        
        AbpAuthenticateResultModel AuthenticateResultModel { get; set; }
        
        Task LoginUserAsync();

        Task LogoutAsync();
    }
}
