using Family.Db.Entities;
using Family.WebDb.ChildrenRepository;
using Family.WebDb.GenusRepository;

namespace Family.Logic.GenusService
{
    public class GenusService : IGenusService
    {
        private readonly IGenusRepository _repository;
        private readonly IChildrenRepository _childrenRepository;

        public GenusService(IGenusRepository repository, IChildrenRepository childrenRepository)
        {
            _repository = repository;
            _childrenRepository = childrenRepository;
        }

        public async Task<IEnumerable<Genus>> GetAllGenus()
        {
            return await _repository.GetAllGenus();
        }

        public async Task<Genus> GetGenus(int id)
        {
            return await _repository.GetGenus(id);
        }
    }
}
