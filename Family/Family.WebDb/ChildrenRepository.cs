using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb
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
    }
}
