using Family.Db.Entities;

namespace Family.Logic.WebService.ChildService
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<Child> GetChild(int id);

        Task CreateChild(Child createdChild);

        Task EditChild(Child editedChild, int id);

        Task DeleteChild(int id);
    }
}