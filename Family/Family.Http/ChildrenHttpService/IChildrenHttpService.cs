using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.ChildrenHttpService
{
    public interface IChildrenHttpService
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Parent>> GetChildrenParents(int childId);

        Task<Child> GetChild(int childId);
    }
}