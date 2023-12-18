using Family.Db;
using Family.Db.Entities.Users;

namespace Family.WebDb.UsersRepository.GodRepository
{
    public class GodRepository : IGodRepository
    {
        private readonly FamilyContext _context;

        public GodRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task UserToAdminAsync(User userToAdmin)
        {
            await _context.SaveChangesAsync();
        }

        public async Task AdminToUserAsync(User adminToUser)
        {
            await _context.SaveChangesAsync();
        }
    }
}
