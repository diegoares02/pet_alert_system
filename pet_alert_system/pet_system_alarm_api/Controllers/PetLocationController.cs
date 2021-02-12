using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PetLocationController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;
        public PetLocationController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_context.PetLocations.Where(item => item.PetId == id));
        }
        [HttpGet("GetLast/{id}")]
        public JsonResult GetLast(int id)
        {
            return new JsonResult(_context.PetLocations.Where(item => item.PetId == id).OrderBy(item => item.Id).Last());
        }
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] PetLocation petLocation)
        {
            _context.PetLocations.Add(petLocation);
            await _context.SaveChangesAsync();
            return new JsonResult(new { result = "Ok", petId = petLocation.PetId });
        }
    }
}
