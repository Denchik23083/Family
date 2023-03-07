using System.Collections.Generic;
using Family.Core;

namespace Family.Db.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public GenderType GenderType { get; set; }
    }
}
