using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>> GetAllParents();
    }
}