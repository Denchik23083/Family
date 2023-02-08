using System.Collections.Generic;

namespace Family.Db.Entities
{
    public class Parent
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public List<ParentsChildren> ParentsChildren { get; set; }
    }
}
