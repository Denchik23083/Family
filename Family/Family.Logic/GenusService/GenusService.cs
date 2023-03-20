using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Parent>> GetAllGenusParents()
        {
            var allGenus = await _repository.GetAllGenus();

            return await _repository.GetAllGenusParents(allGenus);
        }

        public async Task<IEnumerable<Child>> GetAllGenusChildren()
        {
            var allGenus = await _repository.GetAllGenus();

            return await _repository.GetAllGenusChildren(allGenus);
        }

        public async Task<Genus> GetGenus(int id)
        {
            return await _repository.GetGenus(id);
        }

        public async Task CreateGenus(Genus createdGenus)
        {
            var listChildren = new List<Child>();

            var parentsChildren = new List<ParentsChildren>();
            
            foreach (var createdGenusChild in createdGenus.Children)
            {
                var child = await _childrenRepository.GetChild(createdGenusChild.Id);

                listChildren.Add(child);

                parentsChildren.Add(new ParentsChildren
                {
                    ParentId = createdGenus.FatherId,
                    ChildId = createdGenusChild.Id
                });
                parentsChildren.Add(new ParentsChildren
                {
                    ParentId = createdGenus.MotherId,
                    ChildId = createdGenusChild.Id
                });
            }

            createdGenus.Children = null;

            await _repository.CreateGenus(createdGenus, parentsChildren, listChildren);
        }

        public async Task EditGenus(Genus editedGenus, int id)
        {
            var genusToEdit = await _repository.GetGenus(id);

            if (genusToEdit is null)
            {
                throw new ArgumentNullException();
            }

            var listChildren = new List<Child>();

            var parentsChildren = new List<ParentsChildren>();

            foreach (var createdGenusChild in editedGenus.Children)
            {
                var child = await _childrenRepository.GetChild(createdGenusChild.Id);

                listChildren.Add(child);

                parentsChildren.Add(new ParentsChildren
                {
                    ParentId = editedGenus.FatherId,
                    ChildId = createdGenusChild.Id
                });
                parentsChildren.Add(new ParentsChildren
                {
                    ParentId = editedGenus.MotherId,
                    ChildId = createdGenusChild.Id
                });
            }

            editedGenus.Children = null;

            await _repository.EditGenus(genusToEdit, editedGenus, parentsChildren, listChildren);
        }

        public async Task DeleteGenus(int id)
        {
            var genusToDelete = await _repository.GetGenus(id);

            if (genusToDelete is null)
            {
                throw new ArgumentNullException();
            }

            await _repository.DeleteGenus(genusToDelete);
        }
    }
}
