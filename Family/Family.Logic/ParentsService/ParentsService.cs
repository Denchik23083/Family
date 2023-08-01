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

        public async Task CreateParent(Parent createdParent)
        {
            await _repository.CreateParent(createdParent);
        }

        public async Task EditParent(Parent editedParent, int id)
        {
            var parentToEdit = await _repository.GetParent(id);

            if (parentToEdit is null)
            {
                throw new ArgumentNullException();
            }

            parentToEdit.FirstName = editedParent.FirstName;
            parentToEdit.LastName = editedParent.LastName;
            parentToEdit.Age = editedParent.Age;

            await _repository.EditParent(parentToEdit);
        }

        public async Task DeleteParent(int id)
        {
            var parentToDelete = await _repository.GetParent(id);

            if (parentToDelete is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.DeleteParent(parentToDelete);
        }
    }
}
