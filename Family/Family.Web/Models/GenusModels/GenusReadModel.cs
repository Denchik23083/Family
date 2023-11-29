using Family.Db.Entities;

namespace Family.Web.Models.GenusModels
{
    public class GenusReadModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Parent>? Parents { get; set; }

        public List<Child>? Children { get; set; }
    }
}
