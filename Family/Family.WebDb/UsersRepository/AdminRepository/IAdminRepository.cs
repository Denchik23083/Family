using Family.Db.Entities;

namespace Family.WebDb.UsersRepository.AdminRepository
{
    public interface IAdminRepository
    {
        Task<IEnumerable<User>?> GetAdminsAsync(int roleId);

        Task RemoveUserAsync(User userToRemove);
    }
}
