using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http
{
    public interface IParentHttpRepository
    {
        Task<IEnumerable<Parent>> GetAllParents();
    }
}