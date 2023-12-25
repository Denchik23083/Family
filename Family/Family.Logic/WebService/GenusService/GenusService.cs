using Family.Core.Exceptions;
using Family.Db.Entities.Users;
using Family.Db.Entities.Web;
using Family.WebDb.UsersRepository.UserRepository;
using Family.WebDb.WebRepository.GenusRepository;

namespace Family.Logic.WebService.GenusService
{
    public class GenusService : IGenusService
    {
        private readonly IGenusRepository _repository;
        private readonly IUserRepository _userRepository;

        public GenusService(IGenusRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
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
            //TODO: Testing
            foreach (var item in mappedGenus.Parents!)
            {
                item.User!.RoleId = 3;
            }

            foreach (var item in mappedGenus.Children!)
            {
                item.User!.RoleId = 4;
            }

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

        public async Task DeleteGenusAsync(int id)
        {
            var genusToDelete = await _repository.GetGenusAsync(id);

            if (genusToDelete is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            //TODO: Testing
            foreach (var item in genusToDelete.Parents!)
            {
                item.User!.RoleId = 5;
            }

            foreach (var item in genusToDelete.Children!)
            {
                item.User!.RoleId = 5;
            }

            await _repository.DeleteGenusAsync(genusToDelete);
        }

        public async Task AddParentAsync(User parentToAdd, int id)
        {
            var genus = await _repository.GetGenusAsync(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            if (parentToAdd is null)
            {
                throw new UserNotFoundException("User not found");
            }

            parentToAdd.RoleId = 3;

            genus.Parents!.Add(new Parent { User = parentToAdd });

            await _repository.AddParentAsync(genus);
        }

        public async Task AddChildAsync(User childToAdd, int id)
        {
            var genus = await _repository.GetGenusAsync(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            if (childToAdd is null)
            {
                throw new UserNotFoundException("User not found");
            }

            childToAdd.RoleId = 4;

            genus.Children!.Add(new Child { User = childToAdd });

            await _repository.AddChildAsync(genus);
        }
    }
}
