using Family.Core.Exceptions;
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
            var children = await _repository.GetAllChildren();

            if (children is null)
            {
                throw new ChildNotFoundException("Children not found");
            }

            return children;
        }

        public async Task<Child> GetChild(int id)
        {
            var child = await _repository.GetChild(id);

            if (child is null)
            {
                throw new ChildNotFoundException("Child not found");
            }

            return child;
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
                throw new ChildNotFoundException("Child not found");
            }

            await _repository.EditChild(childToEdit);
        }

        public async Task DeleteChild(int id)
        {
            var childToDelete = await _repository.GetChild(id);

            if (childToDelete is null)
            {
                throw new ChildNotFoundException("Child not found");
            }

            await _repository.DeleteParent(childToDelete);
        }
    }
}
