using System.Collections.Generic;
using Family.Db.Entities;

namespace Family.WebDb
{
    public interface IParentRepository
    {
        IEnumerable<Parent> GetAllParents();
    }
}