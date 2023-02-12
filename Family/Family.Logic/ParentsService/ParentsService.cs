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

        public async Task<IEnumerable<Child>> GetParentsChildren(int parentId)
        {
            return await _repository.GetParentsChildren(parentId);
        }

        public async Task<Parent> GetParent(int id)
        {
            return await _repository.GetParent(id);
        }
    }
}
