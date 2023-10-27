using Family.Db.Entities;

namespace Family.WebDb.UserRepository
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(int id);
    }
}
