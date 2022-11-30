using Microsoft.EntityFrameworkCore;
using User.API.Data.Interfaces;
using User.API.Entities;

namespace User.API.Data
{
    public class ApplicationDataContext : DbContext, IApplicationDataContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //new DbInitializer(modelBuilder).Seed();
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Accounts> Accounts { get; set; }
    }
}
