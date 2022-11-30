using User.API.Data;
using User.API.Entities;

namespace UserAPI.Integration.Helpers
{
    public static class Utilities
    {
        public static void InitializeDbForTests(ApplicationDataContext db)
        {
            db.Users.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static void ReinitializeDbForTests(ApplicationDataContext db)
        {
            db.Users.RemoveRange(db.Users);
            InitializeDbForTests(db);
        }

        public static List<Users> GetSeedingMessages()
        {
            return new List<Users>()
            {
               new Users() { UserId = Guid.NewGuid(), EmailAddress = "test1@gmail.com", MonthlyExpenses = 100, MonthlySalary = 1000, Name = "test1" },
               new Users() { UserId = Guid.NewGuid(), EmailAddress = "test2@gmail.com", MonthlyExpenses = 200, MonthlySalary = 2000, Name = "test2" }
            };
        }
    }
}
