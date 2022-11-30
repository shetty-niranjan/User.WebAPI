using Microsoft.EntityFrameworkCore;
using System;
using User.API.Entities;

namespace User.API.SeedData
{

    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<Users>().HasData(
           new Users() { UserId = Guid.NewGuid(), EmailAddress = "test1@gmail.com", MonthlyExpenses = 100, MonthlySalary = 1000, Name = "test1" },
           new Users() { UserId = Guid.NewGuid(), EmailAddress = "test2@gmail.com", MonthlyExpenses = 200, MonthlySalary = 2000, Name = "test2" }

               );
        }
    }
}

