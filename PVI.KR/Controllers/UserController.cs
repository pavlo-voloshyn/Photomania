using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PVI.KR.DataAccess.Entities;
using PVI.KR.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PVI.KR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private IConfiguration _configuration;

        public UserController(IMapper mapper, UserManager<User> userManager, IConfiguration config)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = config;
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            var userEntity = _mapper.Map<User>(userRegister);

            var result = await _userManager.CreateAsync(userEntity);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userEntity.UserName);
                await _userManager.AddToRoleAsync(user, "User");
                await _userManager.AddPasswordAsync(user, userRegister.Password);
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors.First().Description);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(UserLogin userLogin)
        {
            if (userLogin != null && userLogin.Username != null && userLogin.Password != null)
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);

                if (user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user.UserName),
                        new Claim("Id", user.Id.ToString()),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, (await _userManager.GetRolesAsync(user)).First())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(60),
                        signingCredentials: signIn);

                    return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return BadRequest("Invalid username or password");
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
