using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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

        public async Task<IEnumerable<Parent>> GetAllGenusParents(IEnumerable<Genus> allGenus)
        {
            var parents = await _context.Parents
                .Include(_ => _.Gender)
                .ToListAsync();

            foreach (var genus in allGenus)
            {
                parents = parents
                    .Where(_ => _.Id != genus.FatherId && _.Id != genus.MotherId)
                    .ToList();
            }

            return parents;
        }

        public async Task<IEnumerable<Child>> GetAllGenusChildren(IEnumerable<Genus> allGenus)
        {
            var children = await _context.Children
                .Include(_ => _.Gender)
                .ToListAsync();

            foreach (var genus in allGenus)
            {
                children = children
                    .Where(_ => _.GenusId != genus.Id && _.GenusId != genus.Id)
                    .ToList();
            }

            return children;
        }

        public async Task<Genus> GetGenus(int id)
        {
            return await _context.Genus
                .Include(_ => _.Father)
                .ThenInclude(_ => _.Gender)
                .Include(_ => _.Mother)
                .ThenInclude(_ => _.Gender)
                .Include(_ => _.Children)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task CreateGenus(Genus createdGenus, List<ParentsChildren> parentsChildren, List<Child> listChildren)
        {
            _context.Genus.Add(createdGenus);

            foreach (var listChild in listChildren)
            {
                listChild.Genus = createdGenus;
            }

            await _context.ParentsChildren.AddRangeAsync(parentsChildren);

            await _context.SaveChangesAsync();
        }
    }
}
