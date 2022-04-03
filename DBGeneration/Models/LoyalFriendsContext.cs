using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DBGeneration.Models.Mapping;

namespace DBGeneration.Models
{
    public partial class LoyalFriendsContext : DbContext
    {
        static LoyalFriendsContext()
        {
            Database.SetInitializer<LoyalFriendsContext>(null);
        }

        public LoyalFriendsContext()
            : base("Name=LoyalFriendsContext")
        {
        }

        public DbSet<Corporate> Corporates { get; set; }
        public DbSet<CorporateCommentsHistory> CorporateCommentsHistories { get; set; }
        public DbSet<CorporateRejectedReasonHistory> CorporateRejectedReasonHistories { get; set; }
        public DbSet<CorporateStatusHistory> CorporateStatusHistories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerRejectedReasonHistory> CustomerRejectedReasonHistories { get; set; }
        public DbSet<CustomerStatusHistory> CustomerStatusHistories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LookupCategory> LookupCategories { get; set; }
        public DbSet<Lookup> Lookups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CorporateMap());
            modelBuilder.Configurations.Add(new CorporateCommentsHistoryMap());
            modelBuilder.Configurations.Add(new CorporateRejectedReasonHistoryMap());
            modelBuilder.Configurations.Add(new CorporateStatusHistoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new CustomerRejectedReasonHistoryMap());
            modelBuilder.Configurations.Add(new CustomerStatusHistoryMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LookupCategoryMap());
            modelBuilder.Configurations.Add(new LookupMap());
        }
    }
}
