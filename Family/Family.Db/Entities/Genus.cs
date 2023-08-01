namespace Family.Db.Entities
{
    public class Genus
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }
        
        public int FatherId { get; set; }

        public Parent? Father { get; set; }
        
        public int MotherId { get; set; }

        public Parent? Mother { get; set; }

        public List<Child>? Children { get; set; }
    }
}
