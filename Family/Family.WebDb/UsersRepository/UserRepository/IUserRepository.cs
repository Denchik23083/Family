using Family.Db.Entities.Users;

namespace Family.WebDb.UsersRepository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Gender>?> GetGendersAsync();

        Task<IEnumerable<User>?> GetParentsChildrenUsersAsync(int[] roles);

        Task<IEnumerable<User>?> GetUsersAsync(int roleId);

        Task<User?> GetUserAsync(int id);

        Task LeaveGenusAsync(User user);

        Task UpdateUserAsync(User user);
    }
}
