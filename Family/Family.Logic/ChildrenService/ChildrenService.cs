using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb.ChildrenRepository;

namespace Family.Logic.ChildrenService
{
    public class ChildrenService : IChildrenService
    {
        private readonly IChildrenRepository _repository;

        public ChildrenService(IChildrenRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Child>> GetAllChildren()
        {
            return await _repository.GetAllChildren();
        }

        public async Task<IEnumerable<Child>> GetChildren(int id)
        {
            return await _repository.GetParentChildren(id);
        }
    }
}
