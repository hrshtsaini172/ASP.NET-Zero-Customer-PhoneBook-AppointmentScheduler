using Abp.AutoMapper;
using MyTraining1121AngularDemo.Organizations.Dto;

namespace MyTraining1121AngularDemo.Models.Users
{
    [AutoMapFrom(typeof(OrganizationUnitDto))]
    public class OrganizationUnitModel : OrganizationUnitDto
    {
        public bool IsAssigned { get; set; }
    }
}