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

            var father = new User
            {
                Id = 1,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 1
            };

            var mother = new User
            {
                Id = 2,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 2
            };

            var child = new User
            {
                Id = 3,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2010, 01, 01),
                GenderId = 1
            };

            var genusModel = new Genus
            {
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = father,
                        UserId = father.Id
                    },
                    new Parent
                    {
                        User = mother,
                        UserId = mother.Id
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = child,
                        UserId = child.Id
                    }
                }
            };

            _userRepository.Setup(_ => _.GetUserAsync(father.Id))
                .ReturnsAsync(father);

            _userRepository.Setup(_ => _.GetUserAsync(mother.Id))
                .ReturnsAsync(mother);

            _userRepository.Setup(_ => _.GetUserAsync(child.Id))
                .ReturnsAsync(child);

            _repository.Setup(_ => _.CreateGenusAsync(genusModel));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.CreateGenusAsync(genusModel);

            _userRepository.Verify(_ => _.GetUserAsync(father.Id),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(mother.Id),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(child.Id),
                Times.Once);

            _repository.Verify(_ => _.CreateGenusAsync(genusModel),
                Times.Once);

            Assert.Equal(parentRoleId, father.RoleId);
            Assert.Equal(parentRoleId, mother.RoleId);
            Assert.Equal(childRoleId, child.RoleId);
        }

        [Fact]
        public async Task UpdateGenus()
        {
            var expectedId = 1;

            var father = new User
            {
                Id = 1,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 1
            };

            var mother = new User
            {
                Id = 2,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 2
            };

            var child = new User
            {
                Id = 3,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2010, 01, 01),
                GenderId = 1
            };

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = father,
                        UserId = father.Id
                    },
                    new Parent
                    {
                        User = mother,
                        UserId = mother.Id
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = child,
                        UserId = child.Id
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

            var father = new User
            {
                Id = 1,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 1
            };

            var mother = new User
            {
                Id = 2,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 2
            };

            var child = new User
            {
                Id = 3,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2010, 01, 01),
                GenderId = 1
            };

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = father,
                        UserId = father.Id
                    },
                    new Parent
                    {
                        User = mother,
                        UserId = mother.Id
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = child,
                        UserId = child.Id
                    }
                }
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            _userRepository.Setup(_ => _.GetUserAsync(father.Id))
                .ReturnsAsync(father);

            _userRepository.Setup(_ => _.GetUserAsync(mother.Id))
                .ReturnsAsync(mother);

            _userRepository.Setup(_ => _.GetUserAsync(child.Id))
                .ReturnsAsync(child);

            _repository.Setup(_ => _.DeleteGenusAsync(genus));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.DeleteGenusAsync(expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(father.Id),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(mother.Id),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(child.Id),
                Times.Once);

            _repository.Verify(_ => _.DeleteGenusAsync(genus),
                Times.Once);

            Assert.Equal(userRoleId, father.RoleId);
            Assert.Equal(userRoleId, mother.RoleId);
            Assert.Equal(userRoleId, child.RoleId);
        }

        [Fact]
        public async Task AddParent()
        {
            var expectedId = 1;
            var expectedParentsCount = 2;
            var parentRoleId = 3;

            var father = new User
            {
                Id = 1,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 1
            };

            var mother = new User
            {
                Id = 2,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 2
            };

            var child = new User
            {
                Id = 3,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2010, 01, 01),
                GenderId = 1
            };

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = mother,
                        UserId = mother.Id
                    }
                },
                Children = new List<Child>
                {
                    new Child
                    {
                        User = child,
                        UserId = child.Id
                    }
                }
            };

            var parentModel = new Parent
            {
                UserId = father.Id,
                User = father
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            _userRepository.Setup(_ => _.GetUserAsync(parentModel.UserId))
                .ReturnsAsync(father);

            _repository.Setup(_ => _.AddParentAsync(genus));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.AddParentAsync(parentModel, expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(parentModel.UserId),
                Times.Once);

            _repository.Verify(_ => _.AddParentAsync(genus),
                Times.Once);

            Assert.Equal(parentRoleId, father.RoleId);
            Assert.Equal(expectedParentsCount, genus.Parents.Count());
        }

        [Fact]
        public async Task AddChild()
        {
            var expectedId = 1;
            var expectedChildrenCount = 1;
            var childRoleId = 4;

            var father = new User
            {
                Id = 1,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 1
            };

            var mother = new User
            {
                Id = 2,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(1980, 01, 01),
                GenderId = 2
            };

            var child = new User
            {
                Id = 3,
                FirstName = "Test",
                Email = "test@gmail.com",
                Password = "0000",
                BirthDay = new DateTime(2010, 01, 01),
                GenderId = 1
            };

            var genus = new Genus
            {
                Id = expectedId,
                Name = "Tests",
                Parents = new List<Parent>
                {
                    new Parent
                    {
                        User = mother,
                        UserId = mother.Id
                    }
                },
                Children = new List<Child>
                {
                    
                }
            };

            var childModel = new Child
            {
                UserId = child.Id,
                User = child
            };

            _repository.Setup(_ => _.GetGenusAsync(expectedId))
                .ReturnsAsync(genus);

            _userRepository.Setup(_ => _.GetUserAsync(childModel.UserId))
                .ReturnsAsync(child);

            _repository.Setup(_ => _.AddChildAsync(genus));

            IGenusService service = new GenusService(_repository.Object, _userRepository.Object);

            await service.AddChildAsync(childModel, expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId),
                Times.Once);

            _userRepository.Verify(_ => _.GetUserAsync(childModel.UserId),
                Times.Once);

            _repository.Verify(_ => _.AddChildAsync(genus),
                Times.Once);

            Assert.Equal(childRoleId, child.RoleId);
            Assert.Equal(expectedChildrenCount, genus.Children.Count());
        }
    }
}
