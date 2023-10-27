using Family.Core.Exceptions;
using Family.Db.Entities;
using Family.WebDb.UserRepository;

namespace Family.Logic.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _repository.GetUserAsync(id);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            return user;
        }
    }
}
