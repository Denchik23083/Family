using Family.Web.Models.UserModels;
using System.Text.Json.Serialization;

namespace Family.Web.Models.GenderModels
{
    public class GenderReadModel
    {
        public int Id { get; set; }

        public string? Type { get; set; }

        [JsonIgnore]
        public List<UserReadModel>? Users { get; set; }
    }
}
