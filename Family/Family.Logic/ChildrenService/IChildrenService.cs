using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic.ChildrenService
{
    public interface IChildrenService
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Parent>> GetChildrenParents(int id);

        Task<Child> GetChild(int id);

        Task CreateChild(Child createdChild);

        Task EditChild(Child editedChild, int id);

        Task DeleteChild(int id);
    }
}