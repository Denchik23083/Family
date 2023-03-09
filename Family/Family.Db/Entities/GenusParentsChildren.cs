namespace Family.Db.Entities
{
    public class GenusParentsChildren
    {
        public int Id { get; set; }

        public int GenusId { get; set; }

        public Genus Genus { get; set; }

        public int ParentsChildrenId { get; set; }

        public ParentsChildren ParentsChildren { get; set; }
    }
}
