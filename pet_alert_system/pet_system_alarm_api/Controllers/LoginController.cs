using Microsoft.AspNetCore.Mvc;
using pet_system_alarm_api.DAL;
using pet_system_alarm_library.Models;
using pet_system_alarm_library.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pet_system_alarm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;
        public LoginController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        // POST api/<LoginController>
        [HttpPost]
        public UserPetAlarmSystem Post([FromBody] UserPetAlarmSystem userPetAlarmSystem)
        {
            var user = _context.UserPetAlarmSystems
                .SingleOrDefault(item => item.Username == userPetAlarmSystem.Username && item.Password == EncryptDecrypt.EncryptString(userPetAlarmSystem.Password));
            return user;
        }
    }
}
