using Family.Core.Utilities;
using Family.Db.Entities.Users;
using Family.Db.Entities.Web;
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
        public async Task GetParentsChildrenUsers()
        {
            var roles = new int[3] { 3, 4, 5 };

            var parentsChildrenUsers = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Alex",
                    Email = "alex@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(1976, 10, 16),
                    GenderId = 1,
                    RoleId = roles[0]
                },
                new User
                {
                    Id = 2,
                    FirstName = "Denis",
                    Email = "denis@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2003, 08, 23),
                    GenderId = 1,
                    RoleId = roles[1]
                },
                new User
                {
                    Id = 3,
                    FirstName = "Test",
                    Email = "test@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2000, 01, 01),
                    GenderId = 1,
                    RoleId = roles[2]
                }
            };

            _repository.Setup(_ => _.GetParentsChildrenUsersAsync(roles))
                .ReturnsAsync(parentsChildrenUsers);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetParentsChildrenUsersAsync();

            _repository.Verify(_ => _.GetParentsChildrenUsersAsync(roles),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(parentsChildrenUsers.Count, result.Count());
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
        public async Task GetMaleAdults()
        {
            var adult = 18;
            var roleId = 5;

            var maleAdults = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Test",
                    Email = "test@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2000, 01, 01),
                    GenderId = 1,
                    Gender = new Gender() { Type = GenderType.Male },
                    RoleId = roleId
                }
            };

            _repository.Setup(_ => _.GetMaleAdultsAsync(adult, roleId))
                .ReturnsAsync(maleAdults);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetMaleAdultsAsync();

            _repository.Verify(_ => _.GetMaleAdultsAsync(adult, roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(maleAdults.Count, result.Count());
        }

        [Fact]
        public async Task GetFemaleAdults()
        {
            var adult = 18;
            var roleId = 5;

            var femaleAdults = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Test",
                    Email = "test@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2000, 01, 01),
                    GenderId = 2,
                    Gender = new Gender() { Type = GenderType.Female },
                    RoleId = roleId
                }
            };

            _repository.Setup(_ => _.GetFemaleAdultsAsync(adult, roleId))
                .ReturnsAsync(femaleAdults);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetFemaleAdultsAsync();

            _repository.Verify(_ => _.GetFemaleAdultsAsync(adult, roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(femaleAdults.Count, result.Count());
        }

        [Fact]
        public async Task GetYouths()
        {
            var youth = 18;
            var roleId = 5;

            var youths = new List<User>
            {
                new User
                {
                    Id = 1,
                    FirstName = "Test",
                    Email = "test@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2010, 01, 01),
                    GenderId = 1,
                    Gender = new Gender() { Type = GenderType.Male },
                    RoleId = roleId
                }
            };

            _repository.Setup(_ => _.GetYouthsAsync(youth, roleId))
                .ReturnsAsync(youths);

            IUserService service = new UserService(_repository.Object);

            var result = await service.GetYouthsAsync();

            _repository.Verify(_ => _.GetYouthsAsync(youth, roleId),
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(youths.Count, result.Count());
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

        [Fact]
        public async Task LeaveGenus()
        {
            var roleId = 5;

            var expectedId = 5;

            var user = new User
            {
                Id = expectedId,
                FirstName = "Denis",
                Email = "denis@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2003, 08, 23),
                GenderId = 1,
                RoleId = 4,
                Child = new Child
                {
                    Id = 1,
                    GenusId = 1,
                    Genus = new Genus
                    {
                        Id = 1,
                        Name = "Kudryavovs"
                    }
                }
            };

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.LeaveGenusAsync(user));

            IUserService service = new UserService(_repository.Object);

            await service.LeaveGenusAsync(expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.LeaveGenusAsync(user),
                Times.Once);

            Assert.Null(user.Parent);
            Assert.Null(user.Child);
            Assert.Equal(roleId, user.RoleId);
        }

        [Fact]
        public async Task UpdateUser()
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

            var userModel = new User
            {
                FirstName = "Denis2",
                Email = "denis2@gmail.com",
                BirthDay = new DateTime(2000, 06, 21),
                GenderId = 2,
            };

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.UpdateUserAsync(user));

            IUserService service = new UserService(_repository.Object);

            await service.UpdateUserAsync(userModel, expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UpdateUserAsync(user),
                Times.Once);

            Assert.Equal(userModel.FirstName, user.FirstName);
            Assert.Equal(userModel.Email, user.Email);
            Assert.Equal(userModel.BirthDay, user.BirthDay);
            Assert.Equal(userModel.GenderId, user.GenderId);
        }

        [Fact]
        public async Task UpdatePassword()
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

            var passwordModel = new Password
            {
                OldPassword = "0000",
                NewPassword = "1111",
                ConfirmPassword = "1111"
            };

            Assert.Equal(user.Password, passwordModel.OldPassword);
            Assert.Equal(passwordModel.NewPassword, passwordModel.ConfirmPassword);

            _repository.Setup(_ => _.GetUserAsync(expectedId))
                .ReturnsAsync(user);

            _repository.Setup(_ => _.UpdatePasswordAsync(user));

            IUserService service = new UserService(_repository.Object);

            await service.UpdatePasswordAsync(passwordModel, expectedId);

            _repository.Verify(_ => _.GetUserAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UpdatePasswordAsync(user),
                Times.Once);

            Assert.Equal(passwordModel.NewPassword, user.Password);
        }
    }
}
