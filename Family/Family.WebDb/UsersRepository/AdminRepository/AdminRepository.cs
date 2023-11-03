using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.UsersRepository.AdminRepository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FamilyContext _context;

        public AdminRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAdminsAsync(int roleId)
        {
            return await _context.Users
                .Include(_ => _.Gender)
                .Include(_ => _.Parent)
                .Include(_ => _.Child)
                .Where(_ => _.RoleId == roleId)
                .ToListAsync();
        }

        public async Task RemoveUserAsync(User userToRemove)
        {
            _context.Users.Remove(userToRemove);

            await _context.SaveChangesAsync();
        }
    }
}
