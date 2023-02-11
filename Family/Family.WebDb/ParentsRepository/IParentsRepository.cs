using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb.ParentsRepository
{
    public interface IParentsRepository
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<Parent> GetParent(int id);
    }
}