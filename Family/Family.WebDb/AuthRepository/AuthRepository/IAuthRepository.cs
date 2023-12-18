using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;

namespace Family.WebDb.AuthRepository.AuthRepository
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
