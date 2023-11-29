using Family.Core.Exceptions;
using Family.Db.Entities;
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

        public async Task<IEnumerable<Genus>?> GetAllGenus()
        {
            var genus = await _repository.GetAllGenus();

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            return genus;
        }

        public async Task<Genus?> GetGenus(int id)
        {
            var genus = await _repository.GetGenus(id);

            if (genus is null)
            {
                throw new GenusNotFoundException("Genus not found");
            }

            return genus;
        }
    }
}
