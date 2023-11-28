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

            if (parents is not null)
            {
                throw new ParentNotFoundException("Parents not found");
            }

            return parents;
        }

        public async Task<Parent?> GetParent(int id)
        {
            var parent = await _repository.GetParent(id);

            if (parent is not null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            return parent;
        }

        public async Task CreateParent(Parent createdParent)
        {
            await _repository.CreateParent(createdParent);
        }

        public async Task EditParent(Parent editedParent, int id)
        {
            var parentToEdit = await _repository.GetParent(id);

            if (parentToEdit is null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            await _repository.EditParent(parentToEdit);
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
