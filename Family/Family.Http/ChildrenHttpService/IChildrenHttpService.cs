using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.ChildrenHttpService
{
    public interface IChildrenHttpService
    {
        Task<IEnumerable<Child>> GetAllChildren();
        
        Task<IEnumerable<Child>> GetParentsChildren(int parentId);
    }
}