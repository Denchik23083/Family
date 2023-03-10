using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.Logic.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<IEnumerable<Child>> GetGenusChildren(int id);

        Task<Genus> GetGenusParents(int id);
    }
}