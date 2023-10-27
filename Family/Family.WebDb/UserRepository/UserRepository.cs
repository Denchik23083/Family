using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly FamilyContext _context;

        public UserRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Include(_ => _.Parents)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Children)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
