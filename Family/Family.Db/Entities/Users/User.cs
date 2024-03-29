﻿using Family.Db.Entities.Auth;
using Family.Db.Entities.Web;

namespace Family.Db.Entities.Users
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public DateTime BirthDay { get; set; }

        public Gender? Gender { get; set; }

        public int GenderId { get; set; }

        public int? RoleId { get; set; }

        public Role? Role { get; set; }

        public RefreshToken? RefreshToken { get; set; }

        public Parent? Parent { get; set; }

        public Child? Child { get; set; }
    }
}
