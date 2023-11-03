using Family.Db.Entities;

namespace Family.Logic.UsersService.AdminService
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAdminsAsync();

        Task RemoveUserAsync(int id);
    }
}
