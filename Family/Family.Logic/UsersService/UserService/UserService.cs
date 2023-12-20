using Family.Core.Exceptions;
using Family.Db.Entities.Users;
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

        public async Task<IEnumerable<User>> GetParentsChildrenUsersAsync()
        {
            var roles = new int[3] { 3, 4, 5 };

            var users = await _repository.GetParentsChildrenUsersAsync(roles);

            if (users is null)
            {
                throw new UserNotFoundException("Users not found");
            }

            return users;
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

        public async Task LeaveGenusAsync(int userId)
        {
            var user = await _repository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            user.Parent = null;
            user.Child = null;
            user.RoleId = 5;

            await _repository.LeaveGenusAsync(user);
        }

        public async Task UpdateUserAsync(User mappedUser, int userId)
        {
            var user = await _repository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            user.FirstName = mappedUser.FirstName;
            user.Email = mappedUser.Email;
            user.BirthDay = mappedUser.BirthDay;
            user.GenderId = mappedUser.GenderId;

            await _repository.UpdateUserAsync(user);
        }
    }
}
