using System.Collections.Generic;
using System.Threading.Tasks;
using Family.Db.Entities;
using Family.WebDb;

namespace Family.Logic
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
    }
}
