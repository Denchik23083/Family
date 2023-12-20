using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;

namespace Family.Logic.AuthService
{
    public interface IAuthService
    {
        Task RegisterAsync(User register);

        Task<User> LoginAsync(User login);

        Task<User> RefreshAsync(RefreshToken refresh);

        Task CreateRefreshTokenAsync(Guid refreshToken, User user);

        Task UpdateRefreshTokenAsync(Guid refreshToken, User user);
    }
}
