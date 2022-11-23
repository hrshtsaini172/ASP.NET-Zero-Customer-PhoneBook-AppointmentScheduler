using System.Collections.Generic;
using MyTraining1121AngularDemo.Authorization.Permissions.Dto;

namespace MyTraining1121AngularDemo.Authorization.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}