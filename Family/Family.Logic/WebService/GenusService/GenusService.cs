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
            return await _repository.GetAllGenus();
        }

        public async Task<Genus?> GetGenus(int id)
        {
            return await _repository.GetGenus(id);
        }
    }
}
