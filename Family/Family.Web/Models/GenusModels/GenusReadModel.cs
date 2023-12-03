using Family.Db.Entities;
using Family.Web.Models.ChildModels;
using Family.Web.Models.ParentModels;

namespace Family.Web.Models.GenusModels
{
    public class GenusReadModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<ParentReadModel>? Parents { get; set; }

        public List<ChildReadModel>? Children { get; set; }
    }
}
