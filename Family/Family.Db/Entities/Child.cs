using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Family.Db.Entities
{
    public class Child
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        
        public Gender Gender { get; set; }

        public int GenderId { get; set; }

        [JsonIgnore]
        public int? GenusId { get; set; }

        [JsonIgnore]
        public Genus Genus { get; set; }

        [JsonIgnore]
        public List<ParentsChildren> ParentsChildren { get; set; }
    }
}
