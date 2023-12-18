using Family.Db;
using Family.Db.Entities.Web;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.WebRepository.ParentRepository
{
    public class ParentRepository : IParentRepository
    {
        private readonly FamilyContext _context;

        public ParentRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>?> GetAllParentsAsync()
        {
            return await _context.Parents
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Genus)
                .ToListAsync();
        }

        public async Task<Parent?> GetParentAsync(int id)
        {
            return await _context.Parents
                .Include(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Genus)
                .ThenInclude(_ => _!.Children)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Genus)
                .ThenInclude(_ => _!.Parents)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateParent(Parent createdParent)
        {
            await _context.Parents.AddAsync(createdParent);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateParent(Parent parentToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteParent(Parent parentToDelete)
        {
            _context.Parents.Remove(parentToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
