using System.Collections.Generic;
using Family.Db;
using Family.Db.Entities;

namespace Family.WebDb
{
    public class ParentRepository : IParentRepository
    {
        private readonly FamilyContext _context;

        public ParentRepository(FamilyContext context)
        {
            _context = context;
        }

        public IEnumerable<Parent> GetAllParents()
        {
            return _context.Parents;
        }
    }
}
