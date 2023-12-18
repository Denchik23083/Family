using Family.Core.Exceptions;
using Family.Db.Entities.Web;
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

        public async Task<IEnumerable<Child>> GetAllChildrenAsync()
        {
            var children = await _repository.GetAllChildrenAsync();

            if (children is null)
            {
                throw new ChildNotFoundException("Children not found");
            }

            return children;
        }

        public async Task<Child> GetChildAsync(int id)
        {
            var child = await _repository.GetChildAsync(id);

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

        public async Task UpdateChild(Child updatedChild, int id)
        {
            var childToUpdate = await _repository.GetChildAsync(id);

            if (childToUpdate is null)
            {
                throw new ChildNotFoundException("Child not found");
            }

            await _repository.UpdateChild(childToUpdate);
        }

        public async Task DeleteChild(int id)
        {
            var childToDelete = await _repository.GetChildAsync(id);

            if (childToDelete is null)
            {
                throw new ChildNotFoundException("Child not found");
            }

            await _repository.DeleteParent(childToDelete);
        }
    }
}
