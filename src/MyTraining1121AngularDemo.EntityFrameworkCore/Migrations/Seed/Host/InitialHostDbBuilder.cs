using MyTraining1121AngularDemo.EntityFrameworkCore;

namespace MyTraining1121AngularDemo.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly MyTraining1121AngularDemoDbContext _context;

        public InitialHostDbBuilder(MyTraining1121AngularDemoDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
