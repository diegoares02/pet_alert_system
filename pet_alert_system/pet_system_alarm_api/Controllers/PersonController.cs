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
    public class PersonController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;

        public PersonController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.People);
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_context.People.SingleOrDefault(item => item.Id == id));
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Person person)
        {
            if (!_context.People.Contains(person))
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
                return new JsonResult(person);
            }
            else
            {
                return new JsonResult(new { error = "This person is in the database", personId = person.Id });
            }
        }

        // PUT api/<PetController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] Person person)
        {
            var personUpdate = _context.People.SingleOrDefault(item => item == person);
            if (personUpdate != null)
            {
                personUpdate.PhoneNumber = person.PhoneNumber;
                personUpdate.Email = person.Email;
                personUpdate.Address = person.Address;
                personUpdate.Password = person.Password;
                _context.People.Update(personUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(personUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This person is not in the database", personId = person.Id });
            }
        }

        // DELETE api/<PetController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var personUpdate = _context.People.SingleOrDefault(item => item.Id == id);
            if (personUpdate != null)
            {
                _context.People.Remove(personUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(personUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This person is not in the database", personId = id });
            }
        }
    }
}
