using Family.Db.Entities;

namespace Family.WebDb.WebRepository.ParentRepository
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>?> GetAllParents();

        Task<Parent?> GetParent(int id);

        Task CreateParent(Parent createdParent);

        Task EditParent(Parent parentToEdit);

        Task DeleteParent(Parent parentToDelete);
    }
}