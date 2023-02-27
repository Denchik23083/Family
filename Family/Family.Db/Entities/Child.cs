using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public List<ParentsChildren> ParentsChildren { get; set; }
    }
}
