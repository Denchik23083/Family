using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic
{
    public interface IParentsService
    {
        Task<IEnumerable<Parent>> GetAllParents();
    }
}