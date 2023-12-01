using Family.Db.Entities;
using Family.Logic.WebService.GenusService;
using Family.Tests.Utilities;
using Family.WebDb.WebRepository.GenusRepository;
using Moq;
using Xunit;

namespace Family.Tests.WebTests
{
    public class GenusTests : AuthUser
    {
        private readonly Mock<IGenusRepository> _repository;

        public GenusTests()
        {
            _repository = new Mock<IGenusRepository>();
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

            IGenusService service = new GenusService(_repository.Object);

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

            IGenusService service = new GenusService(_repository.Object);

            var result = await service.GetGenusAsync(expectedId);

            _repository.Verify(_ => _.GetGenusAsync(expectedId), 
                Times.Once);

            Assert.NotNull(result);
            Assert.Equal(genus, result);
        }
    }
}
