using Family.Db.Entities;

namespace Family.Logic.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<User> GetUserAsync(int id);
    }
}
