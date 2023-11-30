using Family.Db.Entities;
using Family.Logic.UsersService.GodService;
using Family.Tests.Utilities;
using Family.WebDb.UsersRepository.GodRepository;
using Family.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace Family.Tests.UsersTests
{
    public class GodTests : AuthUser
    {
        private readonly Mock<IGodRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;

        public GodTests()
        {
            _repository = new Mock<IGodRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task UserToAdmin()
        {
            var expectedRoleId = 2;

            var expectedId = 5;

            var userToAdmin = new User
            {
                Id = expectedId,
                FirstName = "Denis",
                LastName = "Kudryavov",
                Email = "denis@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2003, 08, 23),
                GenderId = 1,
                RoleId = 5
            };

            _userRepository.Setup(_ => _.DeleteUserAsync(expectedId))
                .ReturnsAsync(userToAdmin);

            _repository.Setup(_ => _.UserToAdminAsync(userToAdmin));

            IGodService service = new GodService(_repository.Object, _userRepository.Object);

            await service.UserToAdminAsync(expectedId);

            _userRepository.Verify(_ => _.DeleteUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UserToAdminAsync(userToAdmin),
                Times.Once);

            Assert.Equal(expectedRoleId, userToAdmin.RoleId);
        }

        [Fact]
        public async Task AdminToUser()
        {
            var expectedRoleId = 5;

            var expectedId = 2;

            var adminToUser = new User
            {
                Id = expectedId,
                FirstName = "Admin",
                LastName = "Full",
                Email = "admin@gmail.com",
                Password = "0000",
                BirthDay = DateTime.Now.AddYears(-30),
                GenderId = 1,
                RoleId = 2
            };

            _userRepository.Setup(_ => _.DeleteUserAsync(expectedId))
                .ReturnsAsync(adminToUser);

            _repository.Setup(_ => _.AdminToUserAsync(adminToUser));

            IGodService service = new GodService(_repository.Object, _userRepository.Object);

            await service.AdminToUserAsync(expectedId);

            _userRepository.Verify(_ => _.DeleteUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.AdminToUserAsync(adminToUser),
                Times.Once);

            Assert.Equal(expectedRoleId, adminToUser.RoleId);
        }
    }
}
