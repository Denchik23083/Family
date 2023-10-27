using Family.Db.Entities;

namespace Family.Logic.UserService
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);
    }
}
