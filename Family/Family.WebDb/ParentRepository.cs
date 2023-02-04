using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb
{
    public class ParentRepository : IParentRepository
    {
        private readonly FamilyContext _context;

        public ParentRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            return await _context.Parents.ToListAsync();
        }
    }
}
