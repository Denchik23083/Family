using Family.Db.Entities;

namespace Family.Web.Models.GenusModels
{
    public class GenusParentsReadModel
    {
        public int Id { get; set; }

        public int FatherId { get; set; }

        public Parent Father { get; set; }

        public int MotherId { get; set; }

        public Parent Mother { get; set; }
    }
}
