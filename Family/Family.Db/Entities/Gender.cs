using Family.Core.Utilities;

namespace Family.Db.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public GenderType? Type { get; set; }

        public List<User>? Users { get; set; }

        /*[JsonIgnore]
        public List<Parent> Parents { get; set; }

        [JsonIgnore]
        public List<Child> Children { get; set; }*/
    }
}
