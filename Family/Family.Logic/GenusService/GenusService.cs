using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb.GenusRepository;

namespace Family.Logic.GenusService
{
    public class GenusService : IGenusService
    {
        private readonly IGenusRepository _repository;

        public GenusService(IGenusRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Genus>> GetAllGenus()
        {
            return await _repository.GetAllGenus();
        }
    }
}
