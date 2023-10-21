﻿namespace Family.Db.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }
        
        public string? Password { get; set; }

        public int Age { get; set; }

        public Gender? Gender { get; set; }

        public int GenderId { get; set; }

        public int? RoleId { get; set; }

        public Role? Role { get; set; }

        public RefreshToken? RefreshToken { get; set; }
    }
}