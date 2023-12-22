using Family.Db.Entities.Users;

namespace Family.WebDb.UsersRepository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<Gender>?> GetGendersAsync();

        Task<IEnumerable<User>?> GetParentsChildrenUsersAsync(int[] roles);

        Task<IEnumerable<User>?> GetUsersAsync(int roleId);

        Task<IEnumerable<User>?> GetMaleAdultsAsync(int adult, int roleId);

        Task<IEnumerable<User>?> GetFemaleAdultsAsync(int adult, int roleId);

        Task<IEnumerable<User>?> GetYouthsAsync(int youth, int roleId);

        Task<User?> GetUserAsync(int id);

        Task LeaveGenusAsync(User user);

        Task UpdateUserAsync(User user);

        Task UpdatePasswordAsync(User user);
    }
}
