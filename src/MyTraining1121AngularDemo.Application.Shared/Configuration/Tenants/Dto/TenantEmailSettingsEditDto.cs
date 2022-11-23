using Abp.Auditing;
using MyTraining1121AngularDemo.Configuration.Dto;

namespace MyTraining1121AngularDemo.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}