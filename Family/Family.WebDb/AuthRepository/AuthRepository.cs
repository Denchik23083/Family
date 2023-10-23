using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FamilyContext _context;

        public AuthRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task RegisterAsync(User register)
        {
            await _context.Users.AddAsync(register);

            await _context.SaveChangesAsync();
        }

        public async Task<User?> LoginAsync(User login)
        {
            return await _context.Users
                .Include(_ => _.Role)
                .ThenInclude(_ => _!.RolePermission)
                .Include(_ => _.RefreshToken)
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(_ => 
                    _.Email == login.Email && 
                    _.Password == login.Password);
        }
    }
}
