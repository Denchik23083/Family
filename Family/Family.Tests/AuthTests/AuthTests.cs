using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;
using Family.Logic.AuthService;
using Family.Tests.Utilities;
using Family.WebDb.AuthRepository;
using Moq;
using Xunit;

namespace Family.Tests.AuthTests
{
    public class AuthTests : AuthUser
    {
        private readonly Mock<IAuthRepository> _repository;

        public AuthTests()
        {
            _repository = new Mock<IAuthRepository>();
        }

        [Fact]
        public async Task Register()
        {
            var userModel = new User
            {
                FirstName = "Test",
                BirthDay = new DateTime(2000, 10, 10),
                Email = "new@gmail.com",
                Password = "0000",
                GenderId = 2
            };

            _repository.Setup(_ => _.RegisterAsync(userModel));

            IAuthService service = new AuthService(_repository.Object);

            await service.RegisterAsync(userModel);

            _repository.Verify(_ => _.RegisterAsync(userModel),
                Times.Once);
        }

        [Fact]
        public async Task Login()
        {
            var userModel = new User
            {
                Email = "denis@gmail.com",
                Password = "0000"
            };

            var user = User();

            _repository.Setup(_ => _.LoginAsync(userModel))
                .ReturnsAsync(user);

            IAuthService service = new AuthService(_repository.Object);

            var result = await service.LoginAsync(userModel);

            _repository.Verify(_ => _.LoginAsync(userModel),
                Times.Once);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task Refresh()
        {
            var user = User();

            var refreshTokenModel = new RefreshToken
            {
                Value = new Guid(),
            };

            var refreshToken = new RefreshToken
            {
                Value = new Guid(),
                UserId = user.Id,
                User = user
            };

            _repository.Setup(_ => _.RefreshAsync(refreshTokenModel))
                .ReturnsAsync(refreshToken);

            IAuthService service = new AuthService(_repository.Object);

            var result = await service.RefreshAsync(refreshTokenModel);

            _repository.Verify(_ => _.RefreshAsync(refreshTokenModel),
                Times.Once);

            Assert.Equal(user, result);
        }

        [Fact]
        public async Task CreateRefreshToken()
        {
            var user = User();

            var refreshToken = new Guid();

            user.RefreshToken = new RefreshToken
            {
                Value = refreshToken
            };

            _repository.Setup(_ => _.CreateRefreshTokenAsync(user));

            IAuthService service = new AuthService(_repository.Object);

            await service.CreateRefreshTokenAsync(refreshToken, user);

            _repository.Verify(_ => _.CreateRefreshTokenAsync(user),
                Times.Once);
        }

        [Fact]
        public async Task UpdateRefreshToken()
        {
            var user = User();

            var refreshToken = new Guid();

            user.RefreshToken = new RefreshToken
            {
                Value = refreshToken
            };

            user.RefreshToken!.Value = refreshToken;

            _repository.Setup(_ => _.UpdateRefreshTokenAsync(user));

            IAuthService service = new AuthService(_repository.Object);

            await service.UpdateRefreshTokenAsync(refreshToken, user);

            _repository.Verify(_ => _.UpdateRefreshTokenAsync(user),
                Times.Once);
        }
    }
}