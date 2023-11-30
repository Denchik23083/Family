using Family.Db;
using Family.Db.Entities;
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

        public async Task<User?> DeleteUserAsync(int id)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Children)!
                .ThenInclude(_ => _.User)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Parents)!
                .ThenInclude(_ => _.User)
                .Include(_ => _.Child)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Children)!
                .ThenInclude(_ => _.User)
                .Include(_ => _.Child)
                .ThenInclude(_ => _!.Genus)
                .ThenInclude(_ => _!.Parents)!
                .ThenInclude(_ => _.User)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
