using System.ComponentModel.DataAnnotations;

namespace Family.Db.Entities
{
    public class Genus
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ParentsChildrenId { get; set; }

        public ParentsChildren ParentsChildren { get; set; }
    }
}
