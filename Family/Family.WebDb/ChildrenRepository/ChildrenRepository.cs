using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.ChildrenRepository
{
    public class ChildrenRepository : IChildrenRepository
    {
        private readonly FamilyContext _context;

        public ChildrenRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Child>> GetAllChildren()
        {
            return await _context.Children
                .Include(_ => _.Gender)
                .ToListAsync();
        }

        public async Task<IEnumerable<Parent>> GetChildrenParents(int id)
        {
            /*return (await _context.ParentsChildren
                .Where(_ => _.ChildId == id)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _.Gender)
                .Select(_ => _.Parent)
                .ToListAsync())!;*/

            return new List<Parent>();
        }

        public async Task<Child> GetChild(int id)
        {
            return (await _context.Children
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(p => p.Id == id))!;
        }

        public async Task CreateChild(Child createdChild)
        {
            await _context.Children.AddAsync(createdChild);

            await _context.SaveChangesAsync();
        }

        public async Task EditChild(Child childToEdit)
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
