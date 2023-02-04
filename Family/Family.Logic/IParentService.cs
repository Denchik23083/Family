using System.Collections.Generic;
using Family.Db.Entities;

namespace Family.Logic
{
    public interface IParentService
    {
        IEnumerable<Parent> GetAllParents();
    }
}