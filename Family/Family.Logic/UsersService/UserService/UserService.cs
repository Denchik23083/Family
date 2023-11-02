using Family.Core.Exceptions;
using Family.Db.Entities;
using Family.WebDb.UsersRepository.UserRepository;

namespace Family.Logic.UsersService.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Gender>> GetGendersAsync()
        {
            var genders = await _repository.GetGendersAsync();

            if (genders is null)
            {
                throw new GenderNotFoundException("Genders not found");
            }

            return genders;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var roleId = 5;

            var users = await _repository.GetUsersAsync(roleId);

            if (users is null)
            {
                throw new UserNotFoundException("Users not found");
            }

            return users;
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
