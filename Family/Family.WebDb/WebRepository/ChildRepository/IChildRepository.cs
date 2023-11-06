using Family.Db.Entities;

namespace Family.WebDb.WebRepository.ChildRepository
{
    public interface IChildRepository
    {
        Task<IEnumerable<Child>?> GetAllChildren();

        Task<Child?> GetChild(int id);

        Task CreateChild(Child createdChild);

        Task EditChild(Child childToEdit);

        Task DeleteParent(Child childToDelete);
    }
}