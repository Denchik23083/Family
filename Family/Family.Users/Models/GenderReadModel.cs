using Family.Db.Entities;
using System.Text.Json.Serialization;

namespace Family.Users.Models
{
    public class GenderReadModel
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
