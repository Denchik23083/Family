using System.Text.Json.Serialization;

namespace Family.Db.Entities
{
    public class Child
    {
        public int Id { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public int Age { get; set; }
        
        public Gender? Gender { get; set; }

        public int GenderId { get; set; }
        
        public int? GenusId { get; set; }

        [JsonIgnore]
        public Genus? Genus { get; set; }

        [JsonIgnore]
        public List<ParentsChildren>? ParentsChildren { get; set; }
    }
}
