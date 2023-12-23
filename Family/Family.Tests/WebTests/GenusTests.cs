using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;
using Family.Db.Entities.Web;
using Family.Logic.WebService.GenusService;
using Family.Tests.Utilities;
using Family.WebDb.UsersRepository.UserRepository;
using Family.WebDb.WebRepository.GenusRepository;
using Moq;
using Xunit;

namespace Family.Tests.WebTests
{
    public class GenusTests : AuthUser
    {
        private readonly Mock<IGenusRepository> _repository;
        private readonly Mock<IUserRepository> _userRepository;

        public GenusTests()
        {
            _repository = new Mock<IGenusRepository>();
            _userRepository = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task GetAllGenus()
        {
            var genus = new List<Genus>
            {
                new Genus
                {
                    Id = 1,
                    Name = "Kudryavovs"
                }
            };

            _repository.Setup(_ => _.GetAllGenusAsync())
                .ReturnsAsync(genus);

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            var result = await service.GetAllGenusAsync();

            _repository.Verify(_ => _.GetAllGenusAsync(), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(genus.Count, result.Count());
        }

        [Fact]
        public async Task GetGenus()
        {
            var expectedId = 1;

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Kudryavovs"
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            var result = await service.GetGenusAsync(expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(genus, result);
        }

        [Fact]
        public async Task CreateGenus()
        {
            var parentRoleId = 3;
            var childRoleId = 4;

            var genusModel = new Genus
            {
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = new User
                        {
                            Id = 1,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 1
                        }                        
                    },
                    new Parent
                    {
                        User = new User
                        {
                            Id = 2,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 2
                        }
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = new User
                        {
                            Id = 3,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(2010, 01, 01),
                            GenderId = 1
                        }
                    }
                }
            };

            _repository.Setup(_ => _.CreateGenusAsync(genusModel));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.CreateGenusAsync(genusModel);

            _repository.Verify(_ => _.CreateGenusAsync(genusModel),
                Times.Once);

            Assert.True(genusModel.Parents.All(_ => _.User!.RoleId == parentRoleId));
            Assert.True(genusModel.Children.All(_ => _.User!.RoleId == childRoleId));
        }

        [Fact]
        public async Task UpdateGenus()
        {
            var expectedId = 1;

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = new User
                        {
                            Id = 1,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 1
                        }
                    },
                    new Parent
                    {
                        User = new User
                        {
                            Id = 2,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 2
                        }
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = new User
                        {
                            Id = 3,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(2010, 01, 01),
                            GenderId = 1
                        }
                    }
                }
            };

            var genusModel = new Genus
            {
                Name = "Test2"
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            _repository.Setup(_ => _.UpdateGenusAsync(genus));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.UpdateGenusAsync(genusModel, expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.UpdateGenusAsync(genus),
                Times.Once);

            Assert.Equal(genusModel.Name, genus.Name);
        }

        [Fact]
        public async Task DeleteGenus()
        {
            var expectedId = 1;
            var userRoleId = 5;

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = new User
                        {
                            Id = 1,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 1
                        }
                    },
                    new Parent
                    {
                        User = new User
                        {
                            Id = 2,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(1980, 01, 01),
                            GenderId = 2
                        }
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = new User
                        {
                            Id = 3,
                            FirstName = "Test",
                            Email = "test@gmail.com",
                            Password = "0000",
                            BirthDay = new DateTime(2010, 01, 01),
                            GenderId = 1
                        }
                    }
                }
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            _repository.Setup(_ => _.DeleteGenusAsync(genus));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.DeleteGenusAsync(expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId),
                Times.Once);

            _repository.Verify(_ => _.DeleteGenusAsync(genus),
                Times.Once);

            Assert.True(genus.Parents.All(_ => _.User!.RoleId == userRoleId));
            Assert.True(genus.Children.All(_ => _.User!.RoleId == userRoleId));
        }
    }
}
