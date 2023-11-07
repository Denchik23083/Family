using Family.Db.Entities;
using Family.Logic.UsersService.AdminService;
using Family.Tests.Utilities;
using Family.WebDb.UsersRepository.AdminRepository;
using Family.WebDb.UsersRepository.UserRepository;
using Moq;
using Xunit;

namespace Family.Tests.UsersTests
{
    public class AdminTests : AuthUser
    {
        private readonly Mock<IAdminRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;

        public AdminTests()
        {
            _repository = new Mock<IAdminRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetAdmins()
        {
            var roleId = 2;

            var admins = new List<User>
            {
                new User
                {
                    Id = 2,
                    FirstName = "Admin",
                    LastName = "Full",
                    Email = "admin@gmail.com",
                    Password = "0000",
                    BirthDay = DateTime.Now.AddYears(-30),
                    GenderId = 1,
                    RoleId = roleId
                }
            };

            _repository.Setup(_ => _.GetAdminsAsync(roleId))
                .ReturnsAsync(admins);

            IAdminService service = new AdminService(_repository.Object, _userRepository.Object);

            var result = await service.GetAdminsAsync();

            Assert.NotNull(result);
            Assert.Equal(admins.Count, result.Count());
        }

        [Fact]
        public async Task RemoveUser()
        {
            var expectedId = 5;

            var userToRemove = new User
            {
                Id = expectedId,
                FirstName = "Denis",
                LastName = "Kudryavov",
                Email = "denis@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2003, 08, 23),
                GenderId = 1,
                RoleId = 4
            };

            _userRepository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(userToRemove);

            _repository.Setup(_ => _.RemoveUserAsync(userToRemove));

            IAdminService service = new AdminService(_repository.Object, _userRepository.Object);

            await service.RemoveUserAsync(expectedId);

            _userRepository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.RemoveUserAsync(userToRemove),
                Times.Once);
        }
    }
}
