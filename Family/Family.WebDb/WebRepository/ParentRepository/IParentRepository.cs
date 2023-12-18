using Family.Db.Entities.Web;

namespace Family.WebDb.WebRepository.ParentRepository
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>?> GetAllParentsAsync();

        Task<Parent?> GetParentAsync(int id);

        Task CreateParent(Parent createdParent);

        Task UpdateParent(Parent parentToUpdate);

        Task DeleteParent(Parent parentToDelete);
    }
}