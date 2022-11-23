using MyTraining1121AngularDemo.EntityFrameworkCore;

namespace MyTraining1121AngularDemo.Test.Base.TestData
{
    public class TestDataBuilder
    {
        private readonly MyTraining1121AngularDemoDbContext _context;
        private readonly int _tenantId;

        public TestDataBuilder(MyTraining1121AngularDemoDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
