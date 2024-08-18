using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TravelDesk.Context;
using TravelDesk.Models;
using TravelDesk.ViewModels;

namespace TravelDesk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        TravelDeskDbContext _context;
        IConfiguration _configuration;
        public LoginController(TravelDeskDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            IActionResult response = Unauthorized();
            var obj = Authenticate(user);
            CommonTypeRef c= _context.CommonTypes.Where(x => x.Id == obj.RoleId).FirstOrDefault();
            user.RoleName = c.Value;

            if (obj != null)
            {
                var tokenString = GenerateJSONWebToken(obj.Id, obj.Email, user.RoleName);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string GenerateJSONWebToken(int id, string email, string roleName)
        {
            Claim[] claims = new[]
         {
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Sid, id.ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, email),
                 new Claim(ClaimTypes.Role, roleName.ToString()),
                 new Claim(type:"Date", DateTime.Now.ToString())
            };
            var securityKey = new
                 SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            //var securityKey = new SymmetricSecurityKey(_configuration["Jwt:key"]);

            var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
           _configuration["Jwt:Issuer"],
            claims,
expires: DateTime.Now.AddMinutes(120),
signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private User Authenticate(LoginViewModel user)
        {
            User obj = _context.Users.FirstOrDefault(x => x.Email == user.Email
            && x.Password == user.Password);

            return obj;
        }

    }
}
