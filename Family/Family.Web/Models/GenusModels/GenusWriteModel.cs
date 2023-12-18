using Family.Db.Entities.Web;

namespace Family.Web.Models.GenusModels
{
    public class GenusWriteModel
    {
        public string? Name { get; set; }

        public List<Parent>? Parents { get; set; }

        public List<Child>? Children { get; set; }
    }
}
