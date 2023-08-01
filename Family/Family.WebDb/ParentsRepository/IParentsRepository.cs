using Family.Db.Entities;

namespace Family.WebDb.ParentsRepository
{
    public interface IParentsRepository
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<IEnumerable<Child>> GetParentsChildren(int id);

        Task<Parent> GetParent(int id);

        Task CreateParent(Parent createdParent);

        Task EditParent(Parent parentToEdit);

        Task DeleteParent(Parent parentToDelete);
    }
}