using Family.Db.Entities;

namespace Family.Auth.Models
{
    public class TokenModel
    {
        public string? JwtToken { get; set; }

        public Guid RefreshToken { get; set; }
    }
}
