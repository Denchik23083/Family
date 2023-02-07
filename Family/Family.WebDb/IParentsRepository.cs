using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb
{
    public interface IParentsRepository
    {
        Task<IEnumerable<Parent>> GetAllParents();
    }
}