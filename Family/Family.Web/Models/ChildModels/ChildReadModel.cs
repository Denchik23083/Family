using Family.Db.Entities;
using Family.Web.Models.GenusModels;
using Family.Web.Models.UserModels;

namespace Family.Web.Models.ChildModels
{
    public class ChildReadModel
    {
        public int Id { get; set; }

        public UserReadModel? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public GenusReadModel? Genus { get; set; }
    }
}
