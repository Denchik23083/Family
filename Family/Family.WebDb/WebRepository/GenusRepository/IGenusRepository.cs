﻿using Family.Db.Entities.Web;

namespace Family.WebDb.WebRepository.GenusRepository
{
    public interface IGenusRepository
    {
        Task<IEnumerable<Genus>?> GetAllGenusAsync();

        Task<Genus?> GetGenusAsync(int id);

        Task CreateGenusAsync(Genus mappedGenus);

        Task UpdateGenusAsync(Genus genusToUpdate);
                
        Task DeleteGenusAsync(Genus genusToDelete);

        Task AddParentAsync(Genus genus);

        Task AddChildAsync(Genus genus);
    }
}