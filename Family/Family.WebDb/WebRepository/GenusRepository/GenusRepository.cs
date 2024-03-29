﻿using Family.Db;
using Family.Db.Entities.Web;
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

        public async Task<IEnumerable<Genus>?> GetAllGenusAsync()
        {
            return await _context.Genus.ToListAsync();
        }

        public async Task<Genus?> GetGenusAsync(int id)
        {
            return await _context.Genus
                .Include(_ => _.Parents)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .Include(_ => _.Children)!
                .ThenInclude(_ => _.User)
                .ThenInclude(_ => _!.Gender)
                .FirstOrDefaultAsync(_ => _.Id == id);
        }

        public async Task CreateGenusAsync(Genus mappedGenus)
        {
            await _context.Genus.AddAsync(mappedGenus);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateGenusAsync(Genus genusToUpdate)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGenusAsync(Genus genusToDelete)
        {
            _context.Genus.Remove(genusToDelete);

            await _context.SaveChangesAsync();
        }

        public async Task AddParentAsync(Genus genus)
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddChildAsync(Genus genus)
        {
            await _context.SaveChangesAsync();
        }
    }
}
