using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb.ParentsRepository;

namespace Family.Logic.ParentsService
{
    public class ParentsService : IParentsService
    {
        private readonly IParentsRepository _repository;

        public ParentsService(IParentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            return await _repository.GetAllParents();
        }

        public async Task<IEnumerable<Child>> GetParentsChildren(int id)
        {
            return await _repository.GetParentsChildren(id);
        }

        public async Task<Parent> GetParent(int id)
        {
            return await _repository.GetParent(id);
        }

        public Task CreateParent(Parent createdParent)
        {
            throw new System.NotImplementedException();
        }
    }
}
