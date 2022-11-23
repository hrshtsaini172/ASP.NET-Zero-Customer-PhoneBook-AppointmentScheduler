using System.Collections.Generic;
using MyTraining1121AngularDemo.Authorization.Permissions.Dto;

namespace MyTraining1121AngularDemo.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}