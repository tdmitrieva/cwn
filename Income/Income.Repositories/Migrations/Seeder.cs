using Income.Models;
using System;

namespace Income.Repositories.Migrations
{
    internal static class Seeder
    {
        public static void Seed(IncomeDbContext dbContext)
        {
            User user = new User { Email = "test@test.com" };
            dbContext.Users.Add(user);
            dbContext.Users.Add(new User { Email = "user@test.com" });

            Currency currency = new Currency { Name = "Grivna", Symbol = "Grn" };
            dbContext.Currencies.Add(currency);
            dbContext.Currencies.Add(new Currency { Name = "Dollar", Symbol = "USD" });

            dbContext.Finances.Add(new Finance { Date = DateTime.Now, Amount = 5, User = user, Currency = currency });
            dbContext.Finances.Add(new Finance { Date = DateTime.Now, Amount = 10, User = user, Currency = currency });
            dbContext.Finances.Add(new Finance { Date = DateTime.Now, Amount = 15, User = user, Currency = currency });
        }
    }
}
