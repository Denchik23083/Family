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
            return await _context.Parents.ToListAsync();
        }

        public async Task<IEnumerable<Child>> GetParentsChildren(int parentId)
        {
            return await _context.ParentsChildren
                .Where(_ => _.ParentId == parentId)
                .Include(_ => _.Child)
                .Select(_ => _.Child)
                .ToListAsync();
        }

        public async Task<Parent> GetParent(int id)
        {
            return await _context.Parents.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
