using Family.Db.Entities.Web;
using Family.Web.Models.ChildModels;
using Family.Web.Models.ParentModels;

namespace Family.Web.Models.GenusModels
{
    public class GenusWriteModel
    {
        public string? Name { get; set; }

        public List<ParentWriteModel>? Parents { get; set; }

        public List<ChildWriteModel>? Children { get; set; }
    }
}
