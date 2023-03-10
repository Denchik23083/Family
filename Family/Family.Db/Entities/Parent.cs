﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Family.Db.Entities
{
    public class Parent
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public int GenderId { get; set; }
    }
}
