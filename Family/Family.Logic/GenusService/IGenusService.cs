using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<IEnumerable<Parent>> GetAllGenusParents();

        Task<IEnumerable<Child>> GetAllGenusChildren();

        Task<Genus> GetGenus(int id);

        Task CreateGenus(Genus createdGenus);

        Task EditGenus(Genus editedGenus, int id);

        Task DeleteGenus(int id);
    }
}