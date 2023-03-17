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

        public async Task<Genus> GetGenus(int id)
        {
            return await _repository.GetGenus(id);
        }

        public async Task<IEnumerable<Parent>> GetAllGenusParents()
        {
            return await _repository.GetAllGenusParents();
        }

        public async Task<IEnumerable<Child>> GetAllGenusChildren()
        {
            return await _repository.GetAllGenusChildren();
        }
    }
}
