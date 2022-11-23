using Abp;
using Abp.Domain.Services;
using System.Threading.Tasks;

namespace MyTraining1121AngularDemo.Authorization.Users.Profile
{
    public interface IProfileImageService : IDomainService
    {
        Task<string> GetProfilePictureContentForUser(UserIdentifier userIdentifier);
    }
}