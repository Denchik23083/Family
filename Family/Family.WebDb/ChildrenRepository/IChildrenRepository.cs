using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb.ChildrenRepository
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Parent>> GetChildrenParents(int id);

        Task<Child> GetChild(int id);
    }
}