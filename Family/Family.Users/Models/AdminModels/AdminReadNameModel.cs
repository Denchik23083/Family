using Family.Web.Models.GenderModels;

namespace Family.Users.Models.AdminModels
{
    public class AdminReadNameModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? Email { get; set; }
        
        public DateTime BirthDay { get; set; }

        public GenderReadModel? Gender { get; set; }
    }
}
