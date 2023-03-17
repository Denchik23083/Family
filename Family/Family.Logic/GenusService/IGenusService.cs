using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<Genus> GetGenus(int id);

        Task<IEnumerable<Parent>> GetAllGenusParents();

        Task<IEnumerable<Child>> GetAllGenusChildren();
    }
}