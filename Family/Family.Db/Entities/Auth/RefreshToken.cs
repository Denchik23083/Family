using Family.Db.Entities.Users;

namespace Family.Db.Entities.Auth
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public Guid Value { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }
    }
}
