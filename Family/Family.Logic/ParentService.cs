using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb;

namespace Family.Logic
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _repository;

        public ParentService(IParentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Parent>> GetAllParents()
        {
            return await _repository.GetAllParents();
        }
    }
}
