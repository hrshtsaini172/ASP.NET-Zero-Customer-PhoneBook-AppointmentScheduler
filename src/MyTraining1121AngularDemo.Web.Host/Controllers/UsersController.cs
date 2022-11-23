using Abp.AspNetCore.Mvc.Authorization;
using MyTraining1121AngularDemo.Authorization;
using MyTraining1121AngularDemo.Storage;
using Abp.BackgroundJobs;

namespace MyTraining1121AngularDemo.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}