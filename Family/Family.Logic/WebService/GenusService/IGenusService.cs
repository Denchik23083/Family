using Family.Db.Entities.Web;

namespace Family.Logic.WebService.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>?> GetAllGenusAsync();

        Task<Genus?> GetGenusAsync(int id);

        Task CreateGenusAsync(Genus mappedGenus);

        Task UpdateGenusAsync(Genus mappedGenus, int id);

        Task AddParentAsync(int id);

        Task AddChildAsync(int id);

        Task DeleteGenusAsync(int id);
    }
}