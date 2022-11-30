using Microsoft.EntityFrameworkCore;
using User.API.Entities;

namespace User.API.Data.Interfaces
{
    public interface IApplicationDataContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Accounts> Accounts { get; set; }
    }
}
