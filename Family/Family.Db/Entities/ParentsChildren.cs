namespace Family.Db.Entities
{
    public class ParentsChildren
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public Parent Parent { get; set; }

        public int ChildId { get; set; }

        public Child Child { get; set; }
    }
}
