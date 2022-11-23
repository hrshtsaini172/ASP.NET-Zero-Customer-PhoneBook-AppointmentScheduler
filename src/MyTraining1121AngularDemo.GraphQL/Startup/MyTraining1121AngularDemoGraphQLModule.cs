using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo.Startup
{
    [DependsOn(typeof(MyTraining1121AngularDemoCoreModule))]
    public class MyTraining1121AngularDemoGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}