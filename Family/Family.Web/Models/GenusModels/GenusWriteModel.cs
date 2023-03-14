using System.Collections.Generic;
using Family.Db.Entities;

namespace Family.Web.Models.GenusModels
{
    public class GenusWriteModel
    {
        public string Name { get; set; }

        public int FatherId { get; set; }

        public Parent Father { get; set; }

        public int MotherId { get; set; }

        public Parent Mother { get; set; }

        public List<Child> Children { get; set; }
    }
}
