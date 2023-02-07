using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Child>> GetAllChildren();
    }
}