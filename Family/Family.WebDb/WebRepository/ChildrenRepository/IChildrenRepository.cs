using Family.Db.Entities;

namespace Family.WebDb.WebRepository.ChildrenRepository
{
    public interface IChildrenRepository
    {
        Task<IEnumerable<Child>> GetAllChildren();

        Task<IEnumerable<Parent>> GetChildrenParents(int id);

        Task<Child> GetChild(int id);

        Task CreateChild(Child createdChild);

        Task EditChild(Child childToEdit);

        Task DeleteParent(Child childToDelete);
    }
}