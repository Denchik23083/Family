namespace Family.Auth.Models
{
    public class RegisterModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public int? GenderId { get; set; }
    }
}
