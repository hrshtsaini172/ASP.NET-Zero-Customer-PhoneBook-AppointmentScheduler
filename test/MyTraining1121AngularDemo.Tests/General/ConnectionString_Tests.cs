using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace MyTraining1121AngularDemo.Tests.General
{
    // ReSharper disable once InconsistentNaming
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=MyTraining1121AngularDemo; Trusted_Connection=True;");
            csb["Database"].ShouldBe("MyTraining1121AngularDemo");
        }
    }
}
