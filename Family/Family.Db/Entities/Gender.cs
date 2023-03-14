using System.Collections.Generic;
using System.Text.Json.Serialization;
using Family.Core;

namespace Family.Db.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public GenderType GenderType { get; set; }

        [JsonIgnore]
        public List<Parent> Parents { get; set; }

        [JsonIgnore]
        public List<Child> Children { get; set; }
    }
}
