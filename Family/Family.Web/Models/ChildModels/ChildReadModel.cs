using Family.Db.Entities;
using Family.Users.Models;

namespace Family.Web.Models.ChildModels
{
    public class ChildReadModel
    {
        public int Id { get; set; }

        public UserReadModel? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public Genus? Genus { get; set; }
    }
}
