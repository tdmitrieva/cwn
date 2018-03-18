using System.Data.Entity;
using Income.Models;
using System;

namespace Income.Repositories
{
    public class IncomeDbContext: DbContext
    {
        public IncomeDbContext(): base("name=IncomeDataConnection")
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<IncomeDbContext, Migrations.Configuration>("IncomeDataConnection"));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Finance> Finances { get; set; }
    }
}
