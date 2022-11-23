using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyTraining1121AngularDemo.EntityFrameworkCore
{
    public static class MyTraining1121AngularDemoDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyTraining1121AngularDemoDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyTraining1121AngularDemoDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}