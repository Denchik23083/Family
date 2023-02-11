using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb.ChildrenRepository
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Child>> GetParentChildren(int id);
    }
}