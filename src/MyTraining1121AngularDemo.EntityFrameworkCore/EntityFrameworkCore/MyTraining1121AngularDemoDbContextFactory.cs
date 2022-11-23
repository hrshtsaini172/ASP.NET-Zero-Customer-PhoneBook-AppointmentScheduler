using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyTraining1121AngularDemo.Configuration;
using MyTraining1121AngularDemo.Web;

namespace MyTraining1121AngularDemo.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyTraining1121AngularDemoDbContextFactory : IDesignTimeDbContextFactory<MyTraining1121AngularDemoDbContext>
    {
        public MyTraining1121AngularDemoDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyTraining1121AngularDemoDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            MyTraining1121AngularDemoDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyTraining1121AngularDemoConsts.ConnectionStringName));

            return new MyTraining1121AngularDemoDbContext(builder.Options);
        }
    }
}
