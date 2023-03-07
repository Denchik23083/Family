﻿using System.Collections.Generic;
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
            return await _context.Children
                .Include(_ => _.Gender)
                .ToListAsync();
        }

        public async Task<IEnumerable<Parent>> GetChildrenParents(int id)
        {
            return await _context.ParentsChildren
                .Where(_ => _.ChildId == id)
                .Include(_ => _.Parent)
                .ThenInclude(_ => _.Gender)
                .Select(_ => _.Parent)
                .ToListAsync();
        }

        public async Task<Child> GetChild(int id)
        {
            return await _context.Children
                .Include(_ => _.Gender)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateChild(Child createdChild)
        {
            await _context.Children.AddAsync(createdChild);

            await _context.SaveChangesAsync();
        }

        public async Task EditChild(Child childToEdit, Child editedChild, int id)
        {
            childToEdit.FirstName = editedChild.FirstName;
            childToEdit.LastName = editedChild.LastName;
            childToEdit.Age = editedChild.Age;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteParent(Child childToDelete, int id)
        {
            _context.Children.Remove(childToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
