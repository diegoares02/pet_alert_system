using Microsoft.AspNetCore.Authorization;
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
    //[Authorize]
    public class PetController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;
        public PetController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        // GET: api/<PetController>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.Pets);
        }

        // GET api/<PetController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_context.Pets.SingleOrDefault(item => item.Id == id));
        }

        [HttpGet("GetPetByOwner/{id}")]
        public JsonResult GetPetByOwner(int id)
        {
            return new JsonResult(_context.Pets.Where(item => item.PersonId == id));
        }

        // GET api/<PetController>/PetColor
        [HttpGet("GetPetColor")]
        public JsonResult GetPetColor()
        {
            List<ArrayFormat> petColorDictionary = new List<ArrayFormat>();
            foreach (var item in Enum.GetValues(typeof(PetColor)))
            {
                petColorDictionary.Add(new ArrayFormat() { Key = (int)item, Value = Enum.GetName(typeof(PetColor), item) });
            }
            return new JsonResult(petColorDictionary);
        }

        // GET api/<PetController>/PetType
        [HttpGet("GetPetType")]
        public JsonResult GetPetType()
        {
            List<ArrayFormat> petTypeDictionary = new List<ArrayFormat>();

            foreach (var item in Enum.GetValues(typeof(PetType)))
            {
                petTypeDictionary.Add(new ArrayFormat() { Key = (int)item, Value = Enum.GetName(typeof(PetType), item) });
            }
            return new JsonResult(petTypeDictionary);
        }
        // POST api/<PetController>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Pet pet)
        {
            if (!_context.Pets.Contains(pet))
            {
                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();
                return new JsonResult(pet);
            }
            else
            {
                return new JsonResult(new { error = "This pet is in the database", petId = pet.Id });
            }
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] Pet pet)
        {
            var petUpdate = _context.Pets.SingleOrDefault(item => item == pet);
            if (petUpdate != null)
            {
                petUpdate.Age = pet.Age;
                petUpdate.Breed = pet.Breed;
                petUpdate.Height = pet.Height;
                petUpdate.Length = pet.Length;
                petUpdate.Weight = pet.Weight;
                petUpdate.PetPhoto = pet.PetPhoto;
                _context.Pets.Update(petUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(petUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This pet is not in the database", petId = pet.Id });
            }
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var petUpdate = _context.Pets.SingleOrDefault(item => item.Id == id);
            if (petUpdate != null)
            {
                _context.Pets.Remove(petUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(petUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This pet is not in the database", petId = id });
            }
        }
    }
}
