using Family.Core.Utilities;
using Family.Db.Entities.Users;
using Family.Logic.UsersService.UserService;
using Family.Tests.Utilities;
using Family.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace Family.Tests.UsersTests
{
    public class UserTests : AuthUser
    {
        private readonly Mock<IUserRepository> _repository;

        public UserTests()
        {
            _repository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetGenders()
        {
            var genders = new List<Gender>
            {
                new Gender
                {
                    Id = 1,
                    Type = GenderType.Male
                },
                new Gender
                {
                    Id = 2,
                    Type = GenderType.Female
                }
            };

            _repository.Setup(_ => _.GetGendersAsync())
                .ReturnsAsync(genders);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetGendersAsync();

            _repository.Verify(_ => _.GetGendersAsync(), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(genders.Count, result.Count());
        }

        [Fact]
        public async Task GetUsers()
        {
            var roleId = 5;

            var users = new List<User>
            {
                new User
                {
                    Id = 6,
                    FirstName = "Test",
                    Email = "test@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2000, 01, 01),
                    GenderId = 1,
                    RoleId = roleId
                }
            };

            _repository.Setup(_ => _.GetUsersAsync(roleId))
                .ReturnsAsync(users);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetUsersAsync();

            _repository.Verify(_ => _.GetUsersAsync(roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(users.Count, result.Count());
        }

        [Fact]
        public async Task GetUser()
        {
            var expectedId = 5;

            var user = new User
            {
                Id = expectedId,
                FirstName = "Denis",
                Email = "denis@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2003, 08, 23),
                GenderId = 1,
                RoleId = 4
            };

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetUserAsync(expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(user, result);
        }
    }
}
