using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using pet_system_alarm_api.DAL;
using pet_system_alarm_library.Models;
using pet_system_alarm_library.utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pet_system_alarm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;
        private readonly IConfiguration _configuration;
        public LoginController(PetAlarmSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        // POST api/<LoginController>
        [HttpPost]
        public JsonResult Post([FromBody] Person person)
        {
            var user = _context.People
                .SingleOrDefault(item => item.Username == person.Username && item.Password == EncryptDecrypt.EncryptString(person.Password));
            if (user != null)
            {
                var secretKey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretKey);

                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.Email, user.Username));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(createdToken);
                return new JsonResult(new { user = user.Username, token = token });
            }
            else
            {
                return new JsonResult(new { error = "User not authorized", user = person.Username });
            }

        }
    }
}
