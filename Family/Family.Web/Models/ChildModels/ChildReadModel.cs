﻿using Family.Db.Entities;

namespace Family.Web.Models.ChildModels
{
    public class ChildReadModel
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public Gender? Gender { get; set; }

        public int GenderId { get; set; }
    }
}