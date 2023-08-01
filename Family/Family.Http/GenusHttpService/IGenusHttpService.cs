using Family.Db.Entities;

namespace Family.Http.GenusHttpService
{
    public interface IGenusHttpService
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<IEnumerable<Parent>> GetAllGenusParents();

        Task<IEnumerable<Child>> GetAllGenusChildren();

        Task<Genus> GetGenus(int genusId);

        Task CreateGenus(Genus createdGenus);
        
        Task EditGenus(Genus editedGenus, int genusId);

        Task DeleteGenus(int genusId);
    }
}