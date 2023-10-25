﻿using Family.Db.Entities;

namespace Family.WebDb.GenusRepository
{
    public interface IGenusRepository
    {
        Task<IEnumerable<Genus>> GetAllGenus();

        Task<Genus> GetGenus(int id);
    }
}