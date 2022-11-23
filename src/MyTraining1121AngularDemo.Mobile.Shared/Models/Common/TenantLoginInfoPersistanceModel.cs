using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyTraining1121AngularDemo.Sessions.Dto;

namespace MyTraining1121AngularDemo.Models.Common
{
    [AutoMapFrom(typeof(TenantLoginInfoDto)),
     AutoMapTo(typeof(TenantLoginInfoDto))]
    public class TenantLoginInfoPersistanceModel : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}