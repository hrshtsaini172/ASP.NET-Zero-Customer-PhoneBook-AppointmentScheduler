using Abp.Domain.Services;

namespace MyTraining1121AngularDemo
{
    public abstract class MyTraining1121AngularDemoDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected MyTraining1121AngularDemoDomainServiceBase()
        {
            LocalizationSourceName = MyTraining1121AngularDemoConsts.LocalizationSourceName;
        }
    }
}
