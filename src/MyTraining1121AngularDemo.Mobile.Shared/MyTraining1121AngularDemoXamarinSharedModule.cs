using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo
{
    [DependsOn(typeof(MyTraining1121AngularDemoClientModule), typeof(AbpAutoMapperModule))]
    public class MyTraining1121AngularDemoXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoXamarinSharedModule).GetAssembly());
        }
    }
}