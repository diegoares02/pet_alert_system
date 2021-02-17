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
            var locations = _context.PetLocations;
            var people = _context.People;
            var pets = _context.Pets.Where(item => item.PersonId == id).AsEnumerable();
            var petLocations = (from location in locations
                                from person in people
                                from pet in pets
                                where location.PetId == pet.Id
                                select new
                                {
                                    PetId = pet.Id,
                                    PetLocation = location.Id,
                                    Latitude = location.Latitude,
                                    Longitude = location.Longitude,
                                    Pet = pet.Name
                                }).AsEnumerable();
            //Get the last pet location
            var result = petLocations.GroupBy(item => item.PetId).Select(order => order.OrderByDescending(o => o.PetLocation).FirstOrDefault()).OrderBy(item => item.PetId);
            return new JsonResult(result);
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
