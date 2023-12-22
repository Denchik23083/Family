using Family.Core.Utilities;
using Family.Db.Entities.Users;

namespace Family.Logic.UsersService.UserService
{
    public interface IUserService
    {
        Task<IEnumerable<Gender>> GetGendersAsync();

        Task<IEnumerable<User>> GetParentsChildrenUsersAsync();

        Task<IEnumerable<User>> GetUsersAsync();

        Task<IEnumerable<User>> GetMaleAdultsAsync();

        Task<IEnumerable<User>> GetFemaleAdultsAsync();

        Task<IEnumerable<User>> GetYouthsAsync();

        Task<User> GetUserAsync(int id);

        Task LeaveGenusAsync(int userId);

        Task UpdateUserAsync(User mappedUser, int userId);
        
        Task UpdatePasswordAsync(Password mappedPassword, int userId);
    }
}
