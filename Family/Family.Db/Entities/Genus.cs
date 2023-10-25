﻿namespace Family.Db.Entities
{
    public class Genus
    {
        public int Id { get; set; }
        
        public string? Name { get; set; }

        public List<Parent>? Parents { get; set; }

        public List<Child>? Children { get; set; }
    }
}
