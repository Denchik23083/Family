using System.Text.Json.Serialization;

namespace Family.Db.Entities
{
    public class ParentsChildren
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        [JsonIgnore]
        public Parent Parent { get; set; }

        public int ChildId { get; set; }

        [JsonIgnore]
        public Child Child { get; set; }
    }
}
