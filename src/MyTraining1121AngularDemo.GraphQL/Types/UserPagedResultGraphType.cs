using Abp.Application.Services.Dto;
using GraphQL.Types;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Types
{
    public class UserPagedResultGraphType : ObjectGraphType<PagedResultDto<UserDto>>
    {
        public UserPagedResultGraphType()
        {
            Name = "UserPagedResultGraphType";
            
            Field(x => x.TotalCount);
            Field(x => x.Items, type: typeof(ListGraphType<UserType>));
        }
    }
}
