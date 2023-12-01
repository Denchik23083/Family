using Family.Db.Entities;
using Family.Logic.WebService.ChildService;
using Family.Tests.Utilities;
using Family.WebDb.WebRepository.ChildRepository;
using Moq;
using Xunit;

namespace Family.Tests.WebTests
{
    public class ChildTests : AuthUser
    {
        private readonly Mock<IChildRepository> _repository;

        public ChildTests()
        {
            _repository = new Mock<IChildRepository>();
        }

        [Fact]
        public async Task GetAllChildren()
        {
            var children = new List<Child>
            {
                new Child
                {
                    Id = 1,
                    UserId = 5,
                    User = new User
                    {
                        Id = 5,
                        FirstName = "Denis",
                        Email = "denis@gmail.com",
                        Password = "0000",
                        BirthDay = new DateTime(2003, 08, 23),
                        GenderId = 1,
                        RoleId = 4
                    }
                },
                new Child
                {
                    Id = 2,
                    UserId = 6,
                    User = new User
                    {
                        Id = 6,
                        FirstName = "Daria",
                        Email = "daria@gmail.com",
                        Password = "0000",
                        BirthDay = new DateTime(2019, 09, 19),
                        GenderId = 2,
                        RoleId = 4
                    }
                }
            };

            _repository.Setup(_ => _.GetAllChildrenAsync())
                .ReturnsAsync(children);

            IChildService service = new ChildService(_repository.Object);

            var result = await service.GetAllChildrenAsync();

            _repository.Verify(_ => _.GetAllChildrenAsync(), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(children.Count, result.Count());
        }

        [Fact]
        public async Task GetChild()
        {
            var expectedId = 1;

            var child = new Child
            {
                Id = expectedId,
                UserId = 5,
                User = new User
                {
                    Id = 5,
                    FirstName = "Denis",
                    Email = "denis@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(2003, 08, 23),
                    GenderId = 1,
                    RoleId = 4
                }
            };

            _repository.Setup(_ => _.GetChildAsync(expectedId))
                .ReturnsAsync(child);

            IChildService service = new ChildService(_repository.Object);

            var result = await service.GetChildAsync(expectedId);

            _repository.Verify(_ => _.GetChildAsync(expectedId), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(child, result);
        }
    }
}
