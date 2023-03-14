using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Http.GenusHttpService
{
    public interface IGenusHttpService
    {
        Task<IEnumerable<Genus>> GetAllGenus();
        
        Task<Genus> GetGenus(int genusId);

        Task CreateGenus(Genus createdGenus);


        /*Task EditParent(Parent editedParent, int parentId);

        Task DeleteParent(int parentId);*/
    }
}