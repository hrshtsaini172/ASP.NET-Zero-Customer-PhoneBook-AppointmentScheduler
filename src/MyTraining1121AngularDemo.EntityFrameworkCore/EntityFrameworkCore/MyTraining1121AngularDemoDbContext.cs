using Abp.IdentityServer4vNext;
using Abp.Zero.EntityFrameworkCore;
using Acme.PhoneBookDemo.PhoneBook;
using Microsoft.EntityFrameworkCore;
using MyTraining1121AngularDemo.Appointments;
using MyTraining1121AngularDemo.Authorization.Delegation;
using MyTraining1121AngularDemo.Authorization.Roles;
using MyTraining1121AngularDemo.Authorization.Users;
using MyTraining1121AngularDemo.Chat;
using MyTraining1121AngularDemo.Customers;
using MyTraining1121AngularDemo.Editions;
using MyTraining1121AngularDemo.Friendships;
using MyTraining1121AngularDemo.MultiTenancy;
using MyTraining1121AngularDemo.MultiTenancy.Accounting;
using MyTraining1121AngularDemo.MultiTenancy.Payments;
using MyTraining1121AngularDemo.PhoneBook;
using MyTraining1121AngularDemo.Storage;

namespace MyTraining1121AngularDemo.EntityFrameworkCore
{
    public class MyTraining1121AngularDemoDbContext : AbpZeroDbContext<Tenant, Role, User, MyTraining1121AngularDemoDbContext>, IAbpPersistedGrantDbContext
    {
        /* Define an IDbSet for each entity of the application */

        public virtual DbSet<BinaryObject> BinaryObjects { get; set; }

        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<ChatMessage> ChatMessages { get; set; }

        public virtual DbSet<SubscribableEdition> SubscribableEditions { get; set; }

        public virtual DbSet<SubscriptionPayment> SubscriptionPayments { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<PersistedGrantEntity> PersistedGrants { get; set; }

        public virtual DbSet<SubscriptionPaymentExtensionData> SubscriptionPaymentExtensionDatas { get; set; }

        public virtual DbSet<UserDelegation> UserDelegations { get; set; }
        
        public virtual DbSet<RecentPassword> RecentPasswords { get; set; }

        public virtual DbSet<Person> Persons { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<CustomerUsers> CustomerUsers { get; set; }

        public virtual DbSet<Appointment> Appointments { get; set; }

        public MyTraining1121AngularDemoDbContext(DbContextOptions<MyTraining1121AngularDemoDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BinaryObject>(b =>
            {
                b.HasIndex(e => new { e.TenantId });
            });

            modelBuilder.Entity<ChatMessage>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId, e.ReadState });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.TargetUserId, e.ReadState });
                b.HasIndex(e => new { e.TargetTenantId, e.UserId, e.ReadState });
            });

            modelBuilder.Entity<Friendship>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.UserId });
                b.HasIndex(e => new { e.TenantId, e.FriendUserId });
                b.HasIndex(e => new { e.FriendTenantId, e.UserId });
                b.HasIndex(e => new { e.FriendTenantId, e.FriendUserId });
            });

            modelBuilder.Entity<Tenant>(b =>
            {
                b.HasIndex(e => new { e.SubscriptionEndDateUtc });
                b.HasIndex(e => new { e.CreationTime });
            });

            modelBuilder.Entity<SubscriptionPayment>(b =>
            {
                b.HasIndex(e => new { e.Status, e.CreationTime });
                b.HasIndex(e => new { PaymentId = e.ExternalPaymentId, e.Gateway });
            });

            modelBuilder.Entity<SubscriptionPaymentExtensionData>(b =>
            {
                b.HasQueryFilter(m => !m.IsDeleted)
                    .HasIndex(e => new { e.SubscriptionPaymentId, e.Key, e.IsDeleted })
                    .IsUnique();
            });

            modelBuilder.Entity<UserDelegation>(b =>
            {
                b.HasIndex(e => new { e.TenantId, e.SourceUserId });
                b.HasIndex(e => new { e.TenantId, e.TargetUserId });
            });

            modelBuilder.ConfigurePersistedGrantEntity();
        }
    }
}
