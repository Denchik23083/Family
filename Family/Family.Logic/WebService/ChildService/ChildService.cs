using Family.Db.Entities;
using Family.WebDb.WebRepository.ChildRepository;

namespace Family.Logic.WebService.ChildService
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _repository;

        public ChildService(IChildRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Child>> GetAllChildren()
        {
            return await _repository.GetAllChildren();
        }

        public async Task<IEnumerable<Parent>> GetChildrenParents(int id)
        {
            return await _repository.GetChildrenParents(id);
        }

        public async Task<Child> GetChild(int id)
        {
            return await _repository.GetChild(id);
        }

        public async Task CreateChild(Child createdChild)
        {
            await _repository.CreateChild(createdChild);
        }

        public async Task EditChild(Child editedChild, int id)
        {
            var childToEdit = await _repository.GetChild(id);

            if (childToEdit is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.EditChild(childToEdit);
        }

        public async Task DeleteChild(int id)
        {
            var childToDelete = await _repository.GetChild(id);

            if (childToDelete is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.DeleteParent(childToDelete);
        }
    }
}
