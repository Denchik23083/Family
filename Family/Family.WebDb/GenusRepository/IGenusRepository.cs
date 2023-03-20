using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb.GenusRepository
{
    public interface IGenusRepository
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<IEnumerable<Parent>> GetAllGenusParents(IEnumerable<Genus> allGenus);

        Task<IEnumerable<Child>> GetAllGenusChildren(IEnumerable<Genus> allGenus);

        Task<Genus> GetGenus(int id);

        Task CreateGenus(Genus createdGenus, List<ParentsChildren> parentsChildren, List<Child> listChildren);
        
        Task EditGenus(Genus genusToEdit, Genus editedGenus, List<ParentsChildren> parentsChildren, List<Child> listChildren);
        
        Task DeleteGenus(Genus genusToDelete);
    }
}