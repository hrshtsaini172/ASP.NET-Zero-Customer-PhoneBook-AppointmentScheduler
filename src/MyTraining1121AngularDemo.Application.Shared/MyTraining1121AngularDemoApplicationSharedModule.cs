using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo
{
    [DependsOn(typeof(MyTraining1121AngularDemoCoreSharedModule))]
    public class MyTraining1121AngularDemoApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoApplicationSharedModule).GetAssembly());
        }
    }
}