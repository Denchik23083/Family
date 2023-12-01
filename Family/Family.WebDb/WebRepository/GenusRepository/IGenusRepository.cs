using Family.Db.Entities;

namespace Family.WebDb.WebRepository.GenusRepository
{
    public interface IGenusRepository
    {
        Task<IEnumerable<Genus>?> GetAllGenusAsync();

        Task<Genus?> GetGenusAsync(int id);
    }
}