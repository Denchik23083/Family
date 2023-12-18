using Family.Db;
using Family.Db.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.UsersRepository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly FamilyContext _context;

        public UserRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>?> GetGendersAsync()
        {
            return await _context.Genders.ToListAsync();
        }

        public async Task<IEnumerable<User>?> GetUsersAsync(int roleId)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Include(_ => _.Parent)
                .Include(_ => _.Child)
                .Where(_ => _.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<User?> GetUserAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Children)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Parents)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Child)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Children)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Child)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Parents)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task LeaveGenusAsync(User user)
        {
            await _context.SaveChangesAsync();
        }
    }
}
