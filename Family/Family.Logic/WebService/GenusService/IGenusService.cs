using Family.Db.Entities;

namespace Family.Logic.WebService.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>?> GetAllGenusAsync();

        Task<Genus?> GetGenusAsync(int id);
    }
}