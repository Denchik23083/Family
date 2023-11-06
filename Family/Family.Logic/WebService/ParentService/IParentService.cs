using Family.Db.Entities;

namespace Family.Logic.WebService.ParentService
{
    public interface IParentService
    {
        Task<IEnumerable<Parent>> GetAllParents();

        Task<Parent> GetParent(int id);

        Task CreateParent(Parent createdParent);

        Task EditParent(Parent editedParent, int id);

        Task DeleteParent(int id);
    }
}