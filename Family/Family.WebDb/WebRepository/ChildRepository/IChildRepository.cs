using Family.Db.Entities;

namespace Family.WebDb.WebRepository.ChildRepository
{
    public interface IChildRepository
    {
        Task<IEnumerable<Child>?> GetAllChildren();

        Task<Child?> GetChild(int id);

        Task CreateChild(Child createdChild);

        Task UpdateChild(Child childToUpdate);

        Task DeleteParent(Child childToDelete);
    }
}