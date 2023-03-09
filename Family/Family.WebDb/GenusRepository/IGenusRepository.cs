using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;

namespace Family.WebDb.GenusRepository
{
    public interface IGenusRepository
    {
        Task<IEnumerable<Genus>> GetAllGenus();
    }
}