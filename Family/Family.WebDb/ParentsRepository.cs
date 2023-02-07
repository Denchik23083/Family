﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db;
using Family.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Family.WebDb
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
    }
}