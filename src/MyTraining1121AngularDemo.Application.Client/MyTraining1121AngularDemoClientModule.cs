using Abp.Modules;
using Abp.Reflection.Extensions;

namespace MyTraining1121AngularDemo
{
    public class MyTraining1121AngularDemoClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoClientModule).GetAssembly());
        }
    }
}
