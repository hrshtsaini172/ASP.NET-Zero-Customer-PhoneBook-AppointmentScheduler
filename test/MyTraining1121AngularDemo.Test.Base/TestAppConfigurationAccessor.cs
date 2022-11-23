using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using MyTraining1121AngularDemo.Configuration;

namespace MyTraining1121AngularDemo.Test.Base
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(MyTraining1121AngularDemoTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
