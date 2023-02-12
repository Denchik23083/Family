using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.ParentsHttpService
{
    public interface IParentsHttpService
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<IEnumerable<Child>> GetParentsChildren(int parentId);

        Task<Parent> GetParent(int parentId);
    }
}