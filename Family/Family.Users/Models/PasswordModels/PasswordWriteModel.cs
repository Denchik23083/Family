namespace Family.Users.Models.PasswordModels
{
    public class PasswordWriteModel
    {
        public string? OldPassword { get; set; }

        public string? NewPassword { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
