using Family.Core.Utilities;
using System.Text.Json.Serialization;

namespace Family.Db.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public GenderType? Type { get; set; }

        [JsonIgnore]
        public List<User>? Users { get; set; }
    }
}
