﻿using AutoMapper;
using Family.Auth.Models;
using Family.Logic.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Family.Logic.UsersService.UserService;
using Family.Core.Exceptions;
using Family.Db.Entities.Auth;
using Family.Db.Entities.Users;

namespace Family.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService service, IUserService userService, IMapper mapper, IConfiguration configuration)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("register/gender")]
        public async Task<IActionResult> GetGenders()
        {
            try
            {
                var genders = await _userService.GetGendersAsync();

                var mappedGenders = _mapper.Map<IEnumerable<GenderReadModel>>(genders);

                return Ok(mappedGenders);
            }
            catch (GenderNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterWriteModel model)
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
        public async Task<IActionResult> Login(LoginWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedUser = _mapper.Map<User>(model);

                var user = await _service.LoginAsync(mappedUser);

                var tokenModel = await GetUserToken(user);

                return Ok(tokenModel);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login/refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var mappedRefresh = _mapper.Map<RefreshToken>(model);

                var user = await _service.RefreshAsync(mappedRefresh);

                var tokenModel = await GetUserToken(user);

                return Ok(tokenModel);
            }
            catch (UserNotFoundException e)
            {
                return BadRequest(e.Message);
            }
        }

        private async Task<TokenModel> GetUserToken(User user)
        {
            var secretKey = _configuration["SecretKey"];

            var secret = Encoding.UTF8.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, user.FirstName!),
                new (ClaimTypes.Email, user.Email!),
                new (ClaimTypes.Gender, user.Gender!.Type.ToString()!),
                new (ClaimTypes.Role, user.Role!.RoleType.ToString()!)
            };

            var rolePermissions = user.Role!.RolePermissions!
                .Select(_ => new Claim("permission", _.PermissionType.ToString()!));

            claims.AddRange(rolePermissions);

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                notBefore: now,
                expires: now.AddMinutes(10),
                claims: claims,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256));

            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var refreshToken = Guid.NewGuid();

            if (user.RefreshToken is null)
            {
                await _service.CreateRefreshTokenAsync(refreshToken, user);
            }
            else
            {
                await _service.UpdateRefreshTokenAsync(refreshToken, user);
            }

            return new TokenModel { JwtToken = stringToken, RefreshToken = refreshToken };
        }
    }
}
