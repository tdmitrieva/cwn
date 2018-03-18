using Income.Models;

namespace Income.Repositories.Migrations
{
    internal static class Seeder
    {
        public static void Seed(IncomeDbContext dbContext)
        {
            dbContext.Users.Add(new User { Email = "test@test.com" });
            dbContext.Users.Add(new User { Email = "user@test.com" });
        }
    }
}
