using System;
using Abp;

namespace MyTraining1121AngularDemo.Authorization.Users.Profile.Dto
{
    public class GetFriendProfilePictureInput
    {
        public long UserId { get; set; }

        public int? TenantId { get; set; }

        public UserIdentifier ToUserIdentifier()
        {
            return new UserIdentifier(TenantId, UserId);
        }
    }
}
