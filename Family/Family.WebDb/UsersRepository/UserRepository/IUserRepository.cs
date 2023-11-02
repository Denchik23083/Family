using Family.Db.Entities;

namespace Family.WebDb.UsersRepository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<IEnumerable<User>> GetUsersAsync(int roleId);

        Task<User?> GetUserAsync(int id);
    }
}
