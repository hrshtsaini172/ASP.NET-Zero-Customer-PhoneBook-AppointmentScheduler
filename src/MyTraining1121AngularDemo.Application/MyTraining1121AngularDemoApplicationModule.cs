using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyTraining1121AngularDemo.Authorization;

namespace MyTraining1121AngularDemo
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(MyTraining1121AngularDemoApplicationSharedModule),
        typeof(MyTraining1121AngularDemoCoreModule)
        )]
    public class MyTraining1121AngularDemoApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoApplicationModule).GetAssembly());
        }
    }
}