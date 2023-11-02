using Family.Db.Entities;

namespace Family.Logic.WebService.ParentsService
{
    public interface IParentsService
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<IEnumerable<Child>> GetParentsChildren(int id);

        Task<Parent> GetParent(int id);

        Task CreateParent(Parent createdParent);

        Task EditParent(Parent editedParent, int id);

        Task DeleteParent(int id);
    }
}