using System;
using System.IO;
using Abp;
using Abp.AspNetZeroCore;
using Abp.AutoMapper;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Modules;
using Abp.Net.Mail;
using Abp.TestBase;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Configuration;
using MyTraining1121AngularDemo.EntityFrameworkCore;
using MyTraining1121AngularDemo.MultiTenancy;
using MyTraining1121AngularDemo.Security.Recaptcha;
using MyTraining1121AngularDemo.Test.Base.DependencyInjection;
using MyTraining1121AngularDemo.Test.Base.UiCustomization;
using MyTraining1121AngularDemo.Test.Base.Url;
using MyTraining1121AngularDemo.Test.Base.Web;
using MyTraining1121AngularDemo.UiCustomization;
using MyTraining1121AngularDemo.Url;
using NSubstitute;

namespace MyTraining1121AngularDemo.Test.Base
{
    [DependsOn(
        typeof(MyTraining1121AngularDemoApplicationModule),
        typeof(MyTraining1121AngularDemoEntityFrameworkCoreModule),
        typeof(AbpTestBaseModule))]
    public class MyTraining1121AngularDemoTestBaseModule : AbpModule
    {
        public MyTraining1121AngularDemoTestBaseModule(MyTraining1121AngularDemoEntityFrameworkCoreModule abpZeroTemplateEntityFrameworkCoreModule)
        {
            abpZeroTemplateEntityFrameworkCoreModule.SkipDbContextRegistration = true;
        }

        public override void PreInitialize()
        {
            var configuration = GetConfiguration();

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;

            Configuration.UnitOfWork.Timeout = TimeSpan.FromMinutes(30);
            Configuration.UnitOfWork.IsTransactional = false;

            //Disable static mapper usage since it breaks unit tests (see https://github.com/aspnetboilerplate/aspnetboilerplate/issues/2052)
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;

            //Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            RegisterFakeService<AbpZeroDbMigrator>();

            IocManager.Register<IAppUrlService, FakeAppUrlService>();
            IocManager.Register<IWebUrlService, FakeWebUrlService>();
            IocManager.Register<IRecaptchaValidator, FakeRecaptchaValidator>();

            Configuration.ReplaceService<IAppConfigurationAccessor, TestAppConfigurationAccessor>();
            Configuration.ReplaceService<IEmailSender, NullEmailSender>(DependencyLifeStyle.Transient);
            Configuration.ReplaceService<IUiThemeCustomizerFactory, NullUiThemeCustomizerFactory>();

            Configuration.Modules.AspNetZero().LicenseCode = configuration["AbpZeroLicenseCode"];

            //Uncomment below line to write change logs for the entities below:
            Configuration.EntityHistory.IsEnabled = true;
            Configuration.EntityHistory.Selectors.Add("MyTraining1121AngularDemoEntities", typeof(User), typeof(Tenant));
        }

        public override void Initialize()
        {
            ServiceCollectionRegistrar.Register(IocManager);
        }

        private void RegisterFakeService<TService>()
            where TService : class
        {
            IocManager.IocContainer.Register(
                Component.For<TService>()
                    .UsingFactoryMethod(() => Substitute.For<TService>())
                    .LifestyleSingleton()
            );
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return AppConfigurations.Get(Directory.GetCurrentDirectory(), addUserSecrets: true);
        }
    }
}
