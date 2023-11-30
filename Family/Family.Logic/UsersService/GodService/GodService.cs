using Family.Core.Exceptions;
using Family.WebDb.UsersRepository.GodRepository;
using Family.WebDb.UsersRepository.UserRepository;

namespace Family.Logic.UsersService.GodService
{
    public class GodService : IGodService
    {
        private readonly IGodRepository _repository;
        private readonly IUserRepository _userRepository;

        public GodService(IGodRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task UserToAdminAsync(int id)
        {
            var roleId = 2;

            var userToAdmin = await _userRepository.DeleteUserAsync(id);

            if (userToAdmin is null)
            {
                throw new UserNotFoundException("User not found");
            }

            userToAdmin.RoleId = roleId;

            await _repository.UserToAdminAsync(userToAdmin);
        }

        public async Task AdminToUserAsync(int id)
        {
            var roleId = 5;

            var adminToUser = await _userRepository.DeleteUserAsync(id);

            if (adminToUser is null)
            {
                throw new UserNotFoundException("User not found");
            }

            adminToUser.RoleId = roleId;

            await _repository.AdminToUserAsync(adminToUser);
        }
    }
}
