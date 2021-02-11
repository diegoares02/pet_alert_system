using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pet_system_alarm_api.DAL;
using pet_system_alarm_library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pet_system_alarm_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;

        public PersonController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<Pet> Get()
        {
            return _context.Pets.Where(item => item.PersonId == 2).ToList();
        }
    }
}
