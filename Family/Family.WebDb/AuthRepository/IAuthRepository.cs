﻿using Family.Db.Entities;

namespace Family.WebDb.AuthRepository
{
    public interface IAuthRepository
    {
        Task RegisterAsync(User register);

        Task<User?> LoginAsync(User login);

        Task<RefreshToken?> RefreshAsync(RefreshToken refresh);

        Task CreateRefreshTokenAsync(User user);

        Task UpdateRefreshTokenAsync(User user);       
    }
}
