using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.GenusHttpService
{
    public interface IGenusHttpService
    {
        /*Task<IEnumerable<Parent>> GetAllParents();

        Task<IEnumerable<Child>> GetParentsChildren(int parentId);

        Task<Parent> GetParent(int parentId);*/

        Task<IEnumerable<Parent>> GetAllMothers();

        Task CreateGenus(Genus createdGenus);

        /*Task EditParent(Parent editedParent, int parentId);

        Task DeleteParent(int parentId);*/
    }
}