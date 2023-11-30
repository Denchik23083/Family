using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.WebRepository.ChildRepository
{
    public class ChildRepository : IChildRepository
    {
        private readonly FamilyContext _context;

        public ChildRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Child>?> GetAllChildren()
        {
            return await _context.Children
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .ToListAsync();
        }

        public async Task<Child?> GetChild(int id)
        {
            return await _context.Children
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateChild(Child createdChild)
        {
            await _context.Children.AddAsync(createdChild);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateChild(Child childToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParent(Child childToDelete)
        {
            _context.Children.Remove(childToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
