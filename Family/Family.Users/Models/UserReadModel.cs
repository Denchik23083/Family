using Family.Db.Entities;

namespace Family.Users.Models
{
    public class UserReadModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDay { get; set; }

        public Gender? Gender { get; set; }

        public Parent? Parent { get; set; }

        public Child? Child { get; set; }
    }
}
