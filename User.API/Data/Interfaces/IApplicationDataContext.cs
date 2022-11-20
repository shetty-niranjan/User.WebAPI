using Microsoft.EntityFrameworkCore;
using User.API.Entities;

namespace Catalog.API.Data.Interfaces
{
    public interface IApplicationDataContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Accounts> Accounts { get; set; }
    }
}
