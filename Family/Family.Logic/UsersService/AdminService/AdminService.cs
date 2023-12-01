using Family.Core.Exceptions;
using Family.Db.Entities;
using Family.WebDb.UsersRepository.AdminRepository;
using Family.WebDb.UsersRepository.UserRepository;

namespace Family.Logic.UsersService.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        private readonly IUserRepository _userRepository;

        public AdminService(IAdminRepository repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAdminsAsync()
        {
            var roleId = 2;

            var admins = await _repository.GetAdminsAsync(roleId);

            if (admins is null)
            {
                throw new UserNotFoundException("Admins not found");
            }

            return admins;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await _userRepository.GetUserAsync(id);

            if (userToDelete is null)
            {
                throw new UserNotFoundException("User not found");
            }

            await _repository.DeleteUserAsync(userToDelete);
        }
    }
}
