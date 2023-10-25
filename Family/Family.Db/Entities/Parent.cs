﻿namespace Family.Db.Entities
{
    public class Parent
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public int UserId { get; set; }

        public int? GenusId { get; set; }

        public Genus? Genus { get; set; }
    }
}
