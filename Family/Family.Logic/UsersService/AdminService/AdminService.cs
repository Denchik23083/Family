using Family.Core.Exceptions;
using Family.Db.Entities;
using Family.WebDb.UsersRepository.AdminRepository;

namespace Family.Logic.UsersService.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;

        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
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
    }
}
