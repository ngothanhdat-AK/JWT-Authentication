using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT_Authentication.Abstraction.Entities;
using JWT_Authentication.Abstraction.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWT_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration) : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);
           
            user.Username = request.Username;
            user.PasswordHash = hashedPassword;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<string> Login(UserDto request)
        {
            if(user.Username != request.Username)
            {
                return BadRequest("User not found");
            }
            if(new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
            {
                return BadRequest("Wrong password");
            }

            string token = GenerateToken(user);
            return Ok(token);
        }
        
        private string GenerateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("Token:Key")!)); ;

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescription = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("Token:Issuer"),
                audience: configuration.GetValue<string>("Token:Audience"),
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescription);
        }
    }
}
