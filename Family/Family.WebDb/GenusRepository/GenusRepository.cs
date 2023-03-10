using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.GenusRepository
{
    public class GenusRepository : IGenusRepository
    {
        private readonly FamilyContext _context;

        public GenusRepository(FamilyContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genus>> GetAllGenus()
        {
            return await _context.Genus.ToListAsync();
        }

        public async Task<IEnumerable<Child>> GetGenusChildren(int id)
        {
            return await _context.Children
                .Include(_ => _.Gender)
                .Where(_ => _.GenusId == id)
                .ToListAsync();
        }

        public async Task<Genus> GetGenusParents(int id)
        {
            return await _context.Genus
                .Include(_ => _.Father)
                .ThenInclude(_ => _.Gender)
                .Include(_ => _.Mother)
                .ThenInclude(_ => _.Gender)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }
    }
}
