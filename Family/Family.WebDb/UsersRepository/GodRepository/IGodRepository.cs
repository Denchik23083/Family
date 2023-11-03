using Family.Db.Entities;

namespace Family.WebDb.UsersRepository.GodRepository
{
    public interface IGodRepository
    {
        Task UserToAdminAsync(User userToAdmin);

        Task AdminToUserAsync(User adminToUser);
    }
}
