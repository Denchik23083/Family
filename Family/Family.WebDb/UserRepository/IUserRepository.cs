using Family.Db.Entities;

namespace Family.WebDb.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<User?> GetUserAsync(int id);
    }
}
