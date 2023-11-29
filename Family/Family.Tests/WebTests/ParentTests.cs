using Family.Db.Entities;
using Family.Logic.WebService.ParentService;
using Family.Tests.Utilities;
using Family.WebDb.WebRepository.ParentRepository;
using Moq;
using Xunit;

namespace Family.Tests.WebTests
{
    public class ParentTests : AuthUser
    {
        private readonly Mock<IParentRepository> _repository;

        public ParentTests()
        {
            _repository = new Mock<IParentRepository>();
        }

        [Fact]
        public async Task GetAllParents()
        {
            var parents = new List<Parent>
            {
                new Parent
                {
                    Id = 1,
                    UserId = 3,
                    User = new User
                    {
                        Id = 3,
                        FirstName = "Alex",
                        LastName = "Kudryavov",
                        Email = "alex@gmail.com",
                        Password = "0000",
                        BirthDay = new DateTime(1976, 10, 16),
                        GenderId = 1,
                        RoleId = 3
                    }
                },
                new Parent
                {
                    Id = 2,
                    UserId = 4,
                    User = new User
                    {
                        Id = 4,
                        FirstName = "Anna",
                        LastName = "Kudryavova",
                        Email = "anna@gmail.com",
                        Password = "0000",
                        BirthDay = new DateTime(1976, 08, 25),
                        GenderId = 2,
                        RoleId = 3
                    }
                }
            };

            _repository.Setup(_ => _.GetAllParents())
                .ReturnsAsync(parents);

            IParentService service = new ParentService(_repository.Object);

            var result = await service.GetAllParents();

            _repository.Verify(_ => _.GetAllParents(), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(parents.Count, result.Count());
        }

        [Fact]
        public async Task GetParent()
        {
            var expectedId = 1;

            var parent = new Parent
            {
                Id = expectedId,
                UserId = 3,
                User = new User
                {
                    Id = 3,
                    FirstName = "Alex",
                    LastName = "Kudryavov",
                    Email = "alex@gmail.com",
                    Password = "0000",
                    BirthDay = new DateTime(1976, 10, 16),
                    GenderId = 1,
                    RoleId = 3
                }
            };

            _repository.Setup(_ => _.GetParent(expectedId))
                .ReturnsAsync(parent);

            IParentService service = new ParentService(_repository.Object);

            var result = await service.GetParent(expectedId);

            _repository.Verify(_ => _.GetParent(expectedId), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(parent, result);
        }
    }
}
