using Family.Core.Exceptions;
using Family.Core.Utilities;
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

        public async Task<IEnumerable<User>> GetMaleAdultsAsync()
        {
            var adult = 18;
            var roleId = 5;

            var maleAdults = await _repository.GetMaleAdultsAsync(adult, roleId);

            if (maleAdults is null)
            {
                throw new UserNotFoundException("Male Adults not found");
            }

            return maleAdults;
        }

        public async Task<IEnumerable<User>> GetFemaleAdultsAsync()
        {
            var adult = 18;
            var roleId = 5;

            var femaleAdults = await _repository.GetFemaleAdultsAsync(adult, roleId);

            if (femaleAdults is null)
            {
                throw new UserNotFoundException("Female Adults not found");
            }

            return femaleAdults;
        }

        public async Task<IEnumerable<User>> GetYouthsAsync()
        {
            var youth = 18;
            var roleId = 5;

            var youths = await _repository.GetYouthsAsync(youth, roleId);

            if (youths is null)
            {
                throw new UserNotFoundException("Youths not found");
            }

            return youths;
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

        public async Task UpdatePasswordAsync(Password mappedPassword, int userId)
        {
            var user = await _repository.GetUserAsync(userId);

            if (user is null)
            {
                throw new UserNotFoundException("User not found");
            }

            user.Password = mappedPassword.NewPassword;

            await _repository.UpdatePasswordAsync(user);
        }
    }
}
