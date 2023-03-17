using System.Collections.Generic;
using Family.Db.Entities;

namespace Family.Web.Models.GenusModels
{
    public class GenusWriteModel
    {
        public string Name { get; set; }

        public int FatherId { get; set; }

        public int MotherId { get; set; }

        public List<Child> Children { get; set; }
    }
}
