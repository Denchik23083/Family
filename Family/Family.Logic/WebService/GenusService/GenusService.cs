using Family.Core.Exceptions;
using Family.Db.Entities.Web;
using Family.WebDb.WebRepository.GenusRepository;

namespace Family.Logic.WebService.GenusService
{
    public class GenusService : IGenusService
    {
        private readonly IGenusRepository _repository;

        public GenusService(IGenusRepository repository)
        {
            _repository = repository;
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
    }
}
