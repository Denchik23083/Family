using Family.Web.Models.GenderModels;
using Family.Web.Models.ChildModels;
using Family.Web.Models.ParentModels;

namespace Family.Web.Models.UserModels
{
    public class UserReadModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDay { get; set; }

        public GenderReadModel? Gender { get; set; }

        public ParentReadModel? Parent { get; set; }

        public ChildReadModel? Child { get; set; }
    }
}
