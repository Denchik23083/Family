using Family.Core.Exceptions;
using Family.Db.Entities;
using Family.WebDb.WebRepository.ParentRepository;

namespace Family.Logic.WebService.ParentService
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _repository;

        public ParentService(IParentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Parent>?> GetAllParents()
        {
            var parents = await _repository.GetAllParents();

            if (parents is null)
            {
                throw new ParentNotFoundException("Parents not found");
            }

            return parents;
        }

        public async Task<Parent?> GetParent(int id)
        {
            var parent = await _repository.GetParent(id);

            if (parent is null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            return parent;
        }

        public async Task CreateParent(Parent createdParent)
        {
            await _repository.CreateParent(createdParent);
        }

        public async Task UpdateParent(Parent updatedParent, int id)
        {
            var parentToUpdate = await _repository.GetParent(id);

            if (parentToUpdate is null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            await _repository.UpdateParent(parentToUpdate);
        }

        public async Task DeleteParent(int id)
        {
            var parentToDelete = await _repository.GetParent(id);

            if (parentToDelete is null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            await _repository.DeleteParent(parentToDelete);
        }
    }
}
