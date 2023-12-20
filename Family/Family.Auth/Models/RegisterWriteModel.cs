namespace Family.Auth.Models
{
    public class RegisterWriteModel
    {
        public string? FirstName { get; set; }

        public DateTime BirthDay { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public int? GenderId { get; set; }
    }
}
