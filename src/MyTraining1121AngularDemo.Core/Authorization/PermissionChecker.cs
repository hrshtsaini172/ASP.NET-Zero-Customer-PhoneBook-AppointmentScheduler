using Abp.Authorization;
using MyTraining1121AngularDemo.Authorization.Roles;
using MyTraining1121AngularDemo.Authorization.Users;

namespace MyTraining1121AngularDemo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
