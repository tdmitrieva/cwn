using System.Data.Entity.Migrations;

namespace Income.Repositories.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<IncomeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IncomeDbContext context)
        {
            Seeder.Seed(context);
        }
    }
}
