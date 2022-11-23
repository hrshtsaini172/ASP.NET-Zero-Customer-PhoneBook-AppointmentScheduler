using AutoMapper;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Dto;

namespace MyTraining1121AngularDemo.Startup
{
    public static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserDto>()
                .ForMember(dto => dto.Roles, options => options.Ignore())
                .ForMember(dto => dto.OrganizationUnits, options => options.Ignore());
        }
    }
}