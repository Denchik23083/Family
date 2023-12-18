using Family.Db.Entities.Users;

namespace Family.Logic.UsersService.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAdminsAsync();

        Task DeleteUserAsync(int id);
    }
}
