using AutoMapper;
using Family.Auth.Models;
using Family.Db.Entities;
using Family.Logic.AuthService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Family.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                return BadRequest("Your password must match confirmPassword");
            }
                
            var mappedUser = _mapper.Map<User>(model);

            await _service.RegisterAsync(mappedUser);

            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedUser = _mapper.Map<User>(model);

            var user = await _service.LoginAsync(mappedUser);

            var tokenModel = GetUserToken(user);

            return Ok(tokenModel);
        }

        private TokenModel GetUserToken(User user)
        {
            return new TokenModel { /*JwtToken = stringToken, RefreshToken = refreshToken*/ };
        }
    }
}
