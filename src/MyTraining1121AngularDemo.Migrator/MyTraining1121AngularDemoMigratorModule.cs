using Abp.AspNetZeroCore;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using MyTraining1121AngularDemo.Configuration;
using MyTraining1121AngularDemo.EntityFrameworkCore;
using MyTraining1121AngularDemo.Migrator.DependencyInjection;

namespace MyTraining1121AngularDemo.Migrator
{
    [DependsOn(typeof(MyTraining1121AngularDemoEntityFrameworkCoreModule))]
    public class MyTraining1121AngularDemoMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MyTraining1121AngularDemoMigratorModule(MyTraining1121AngularDemoEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(MyTraining1121AngularDemoMigratorModule).GetAssembly().GetDirectoryPathOrNull(),
                addUserSecrets: true
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                MyTraining1121AngularDemoConsts.ConnectionStringName
                );
            Configuration.Modules.AspNetZero().LicenseCode = _appConfiguration["AbpZeroLicenseCode"];

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyTraining1121AngularDemoMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}