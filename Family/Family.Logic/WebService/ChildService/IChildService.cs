using Family.Db.Entities;

namespace Family.Logic.WebService.ChildService
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> GetAllChildrenAsync();

        Task<Child> GetChildAsync(int id);

        Task CreateChild(Child createdChild);

        Task UpdateChild(Child updatedChild, int id);

        Task DeleteChild(int id);
    }
}