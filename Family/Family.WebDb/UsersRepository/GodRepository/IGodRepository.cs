using Family.Db.Entities.Users;

namespace Family.WebDb.UsersRepository.GodRepository
{
    public interface IGodRepository
    {
        Task UserToAdminAsync(User userToAdmin);

        Task AdminToUserAsync(User adminToUser);
    }
}
