using Family.Db.Entities.Users;
using Family.Db.Entities.Web;

namespace Family.Logic.WebService.GenusService
{
    public interface IGenusService
    {
        Task<IEnumerable<Genus>?> GetAllGenusAsync();

        Task<Genus?> GetGenusAsync(int id);

        Task CreateGenusAsync(Genus mappedGenus);

        Task UpdateGenusAsync(Genus mappedGenus, int id);

        Task DeleteGenusAsync(int id);

        Task AddParentAsync(Parent mappedParent, int id);

        Task AddChildAsync(Child mappedChild, int id);        
    }
}