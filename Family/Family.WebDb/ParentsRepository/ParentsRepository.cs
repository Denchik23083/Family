using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.ParentsRepository
{
    public class ParentsRepository : IParentsRepository
    {
        private readonly FamilyContext _context;

        public ParentsRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            return await _context.Parents
                .Include(_ => _.Gender)
                .ToListAsync();
        }

        public async Task<IEnumerable<Child>> GetParentsChildren(int id)
        {
            return await _context.ParentsChildren
                .Where(_ => _.ParentId == id)
                .Include(_ => _.Child)
                .ThenInclude(_ => _.Gender)
                .Select(_ => _.Child)
                .ToListAsync();
        }

        public async Task<Parent> GetParent(int id)
        {
            return await _context.Parents
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateParent(Parent createdParent)
        {
            await _context.Parents.AddAsync(createdParent);

            await _context.SaveChangesAsync();
        }

        public async Task EditParent(Parent parentToEdit, Parent editedParent)
        {
            parentToEdit.FirstName = editedParent.FirstName;
            parentToEdit.LastName = editedParent.LastName;
            parentToEdit.Age = editedParent.Age;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteParent(Parent parentToDelete)
        {
            _context.Parents.Remove(parentToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
