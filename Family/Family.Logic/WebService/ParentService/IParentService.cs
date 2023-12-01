using Family.Db.Entities;

namespace Family.Logic.WebService.ParentService
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>?> GetAllParentsAsync();

        Task<Parent?> GetParentAsync(int id);

        Task CreateParent(Parent createdParent);

        Task UpdateParent(Parent updatedParent, int id);

        Task DeleteParent(int id);
    }
}