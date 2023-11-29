using Family.Db.Entities;
using Family.Users.Models;

namespace Family.Web.Models.ParentModels
{
    public class ParentReadModel
    {
        public int Id { get; set; }

        public UserReadModel? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public Genus? Genus { get; set; }
    }
}
