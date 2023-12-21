using Family.Core.Exceptions;
using Family.Db.Entities.Web;
using Family.WebDb.WebRepository.ChildRepository;
using Family.WebDb.WebRepository.GenusRepository;
using Family.WebDb.WebRepository.ParentRepository;

namespace Family.Logic.WebService.GenusService
{
    public class GenusService : IGenusService
    {
        private readonly IGenusRepository _repository;
        private readonly IParentRepository _parentRepository;
        private readonly IChildRepository _childRepository;

        public GenusService(IGenusRepository repository, 
            IParentRepository parentRepository, 
            IChildRepository childRepository)
        {
            _repository = repository;
            _parentRepository = parentRepository;
            _childRepository = childRepository;
        }

        public async Task<IEnumerable<Genus>?> GetAllGenusAsync()
        {
            var genus = await _repository.GetAllGenusAsync();

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            return genus;
        }

        public async Task<Genus?> GetGenusAsync(int id)
        {
            var genus = await _repository.GetGenusAsync(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            return genus;
        }

        public async Task CreateGenusAsync(Genus mappedGenus)
        {
            await _repository.CreateGenusAsync(mappedGenus);
        }

        public async Task UpdateGenusAsync(Genus mappedGenus, int id)
        {
            var genusToUpdate = await _repository.GetGenusAsync(id);

            if (genusToUpdate is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            genusToUpdate.Name = mappedGenus.Name;

            await _repository.UpdateGenusAsync(genusToUpdate);
        }

        public async Task AddParentAsync(int id)
        {
            var genus = await _repository.GetGenusAsync(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            var parentToAdd = await _parentRepository.GetParentAsync(id);

            if (parentToAdd is null)
            {
                throw new ParentNotFoundException("Parent not found");
            }

            genus.Parents!.Add(parentToAdd);

            await _repository.AddParentAsync(genus);
        }

        public async Task AddChildAsync(int id)
        {
            var genus = await _repository.GetGenusAsync(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            var childToAdd = await _childRepository.GetChildAsync(id);

            if (childToAdd is null)
            {
                throw new ChildNotFoundException("Child not found");
            }

            genus.Children!.Add(childToAdd);

            await _repository.AddChildAsync(genus);
        }

        public async Task DeleteGenusAsync(int id)
        {
            var genusToDelete = await _repository.GetGenusAsync(id);

            if (genusToDelete is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            await _repository.DeleteGenusAsync(genusToDelete);
        }
    }
}
