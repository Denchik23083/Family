using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic.ChildrenService
{
    public interface IChildrenService
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Child>> GetChildren(int id);
    }
}