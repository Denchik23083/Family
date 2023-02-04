using System.Collections.Generic;
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

        public IEnumerable<Parent> GetAllParents()
        {
            return _repository.GetAllParents();
        }
    }
}
