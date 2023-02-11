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

        public async Task<IEnumerable<Child>> GetParentChildren(int id)
        {
            return await _context.ParentsChildren
                .Where(_ => _.ParentId == id)
                .Include(_ => _.Child)
                .Select(_ => _.Child)
                .ToListAsync();
        }
    }
}
