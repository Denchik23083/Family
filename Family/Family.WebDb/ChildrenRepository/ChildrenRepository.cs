using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return await _context.Children.ToListAsync();
        }

        public async Task<IEnumerable<Parent>> GetChildrenParents(int id)
        {
            return await _context.ParentsChildren
                .Where(_ => _.ChildId == id)
                .Include(_ => _.Parent)
                .Select(_ => _.Parent)
                .ToListAsync();
        }

        public async Task<Child> GetChild(int id)
        {
            return await _context.Children.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
