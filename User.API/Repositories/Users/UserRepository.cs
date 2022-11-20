using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using User.API.Repositories.Users.Interfaces;

namespace User.API.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDataContext _context;

        public UserRepository(IApplicationDataContext context)
        {
            _context = (ApplicationDataContext)(context ?? throw new ArgumentNullException(nameof(context)));
        }

        public async Task<Entities.Users> CreateUser(Entities.Users user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return await UserById(user.UserId);
        }

        public async Task<IEnumerable<Entities.Users>> Users()
        {
            return await _context.Users
                            .ToListAsync();
        }

        public async Task<bool> UserByEmailAddress(string emailAddress)
        {
            var list = await _context.Users.ToListAsync();
            return list.Any(u => u.EmailAddress == emailAddress);
        }

        public async Task<Entities.Users> UserById(Guid userId)
        {
            var user = await _context
                           .Users
                           .SingleOrDefaultAsync(p => p.UserId == userId);
            return user;
        }

        public async Task<Entities.Users> GetByEmailAddress(string emailAddress)
        {
            var user = await _context
                          .Users
                          .SingleOrDefaultAsync(p => p.EmailAddress == emailAddress);
            return user;
        }
    }
}
