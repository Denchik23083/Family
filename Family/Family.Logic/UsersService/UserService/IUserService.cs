using Family.Db.Entities;

namespace Family.Logic.UsersService.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<IEnumerable<User>> GetUsersAsync();

        Task<User> GetUserAsync(int id);
    }
}
