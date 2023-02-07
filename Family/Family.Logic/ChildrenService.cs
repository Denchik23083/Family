using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb;

namespace Family.Logic
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
    }
}
