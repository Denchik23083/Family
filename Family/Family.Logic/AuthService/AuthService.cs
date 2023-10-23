using Family.Db.Entities;
using Family.WebDb.AuthRepository;

namespace Family.Logic.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repository;

        public AuthService(IAuthRepository repository)
        {
            _repository = repository;
        }

        public async Task RegisterAsync(User register)
        {
            register.RoleId = 5;

            await _repository.RegisterAsync(register);
        }

        public async Task<User> LoginAsync(User login)
        {
            var user = await _repository.LoginAsync(login);

            if (user is null)
            {
                throw new ArgumentNullException("User not found");
            }

            return user;
        }
    }
}
