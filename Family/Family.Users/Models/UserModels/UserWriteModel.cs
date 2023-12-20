using Family.Web.Models.ChildModels;
using Family.Web.Models.GenderModels;
using Family.Web.Models.ParentModels;

namespace Family.Users.Models.UserModels
{
    public class UserWriteModel
    {
        public string? FirstName { get; set; }

        public string? Email { get; set; }

        public DateTime BirthDay { get; set; }

        public int GenderId { get; set; }
    }
}
