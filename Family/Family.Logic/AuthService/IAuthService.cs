using Family.Db.Entities;

namespace Family.Logic.AuthService
{
    public interface IAuthService
    {
        Task RegisterAsync(User register);

        Task<User> LoginAsync(User login);
    }
}
