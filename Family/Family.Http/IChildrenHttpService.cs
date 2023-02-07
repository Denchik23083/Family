using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http
{
    public interface IChildrenHttpService
    {
        Task<IEnumerable<Child>> GetAllChildren();
    }
}