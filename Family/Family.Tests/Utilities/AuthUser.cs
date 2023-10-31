using Family.Db.Entities;

namespace Family.Tests.Utilities
{
    public class AuthUser
    {
        protected static User User()
        {
            return new User
            {
                Id = 5,
                FirstName = "Denis",
                LastName = "Kudryavov",
                Email = "denis@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2003, 08, 23),
                GenderId = 1,
                RoleId = 4
            };
        }
    }
}
