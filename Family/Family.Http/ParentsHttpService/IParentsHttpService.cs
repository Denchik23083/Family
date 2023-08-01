using Family.Db.Entities;

namespace Family.Http.ParentsHttpService
{
    public interface IParentsHttpService
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<IEnumerable<Child>> GetParentsChildren(int parentId);

        Task<Parent> GetParent(int parentId);

        Task CreateParent(Parent createdParent);

        Task EditParent(Parent editedParent, int parentId);

        Task DeleteParent(int parentId);
    }
}