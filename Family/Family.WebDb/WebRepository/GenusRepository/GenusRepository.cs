using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb.WebRepository.GenusRepository
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

        public async Task<Genus> GetGenus(int id)
        {
            return (await _context.Genus
                /*.Include(_ => _.Father)
                .ThenInclude(_ => _.Gender)
                .Include(_ => _.Mother)
                .ThenInclude(_ => _.Gender)
                .Include(_ => _.Children)*/
                .FirstOrDefaultAsync(_ => _.Id == id))!;
        }
    }
}
