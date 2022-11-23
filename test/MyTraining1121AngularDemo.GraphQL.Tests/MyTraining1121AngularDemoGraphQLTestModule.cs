using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MyTraining1121AngularDemo.Configure;
using MyTraining1121AngularDemo.Startup;
using MyTraining1121AngularDemo.Test.Base;

namespace MyTraining1121AngularDemo.GraphQL.Tests
{
    [DependsOn(
        typeof(MyTraining1121AngularDemoGraphQLModule),
        typeof(MyTraining1121AngularDemoTestBaseModule))]
    public class MyTraining1121AngularDemoGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoGraphQLTestModule).GetAssembly());
        }
    }
}