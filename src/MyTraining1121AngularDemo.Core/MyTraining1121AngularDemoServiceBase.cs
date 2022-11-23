using Abp;

namespace MyTraining1121AngularDemo
{
    /// <summary>
    /// This class can be used as a base class for services in this application.
    /// It has some useful objects property-injected and has some basic methods most of services may need to.
    /// It's suitable for non domain nor application service classes.
    /// For domain services inherit <see cref="MyTraining1121AngularDemoDomainServiceBase"/>.
    /// For application services inherit MyTraining1121AngularDemoAppServiceBase.
    /// </summary>
    public abstract class MyTraining1121AngularDemoServiceBase : AbpServiceBase
    {
        protected MyTraining1121AngularDemoServiceBase()
        {
            LocalizationSourceName = MyTraining1121AngularDemoConsts.LocalizationSourceName;
        }
    }
}