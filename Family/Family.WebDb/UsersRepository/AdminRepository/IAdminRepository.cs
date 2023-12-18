using Family.Db.Entities.Users;

namespace Family.WebDb.UsersRepository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>?> GetAdminsAsync(int roleId);

        Task DeleteUserAsync(User userToDelete);
    }
}
