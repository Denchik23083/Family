using Family.Web.Models.GenusModels;
using Family.Web.Models.UserModels;

namespace Family.Web.Models.ParentModels
{
    public class ParentReadModel
    {
        public int Id { get; set; }

        public UserReadModel? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public GenusReadModel? Genus { get; set; }
    }
}
