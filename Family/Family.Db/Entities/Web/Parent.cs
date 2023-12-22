using Family.Db.Entities.Users;

namespace Family.Db.Entities.Web
{
    public class Parent
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }

        //TODO: Remove nullable type
        public int? GenusId { get; set; }

        public Genus? Genus { get; set; }
    }
}
