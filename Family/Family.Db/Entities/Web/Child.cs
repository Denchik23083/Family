using Family.Db.Entities.Users;

namespace Family.Db.Entities.Web
{
    public class Child
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public Genus? Genus { get; set; }
    }
}
