using System.Threading.Tasks;
using Abp.Authorization.Users;
using MyTraining1121AngularDemo.Authorization.Users;

namespace MyTraining1121AngularDemo.Authorization
{
    public static class UserManagerExtensions
    {
        public static async Task<User> GetAdminAsync(this UserManager userManager)
        {
            return await userManager.FindByNameAsync(AbpUserBase.AdminUserName);
        }
    }
}
