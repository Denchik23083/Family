using Family.Db.Entities;

namespace Family.Logic.WebService.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>?> GetAllGenus();

        Task<Genus?> GetGenus(int id);
    }
}