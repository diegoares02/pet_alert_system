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
    public class HospitalController : ControllerBase
    {
        private readonly PetAlarmSystemContext _context;

        public HospitalController(PetAlarmSystemContext context)
        {
            _context = context;
        }
        // GET: api/<HospitalController>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(_context.Hospitals);
        }

        // GET api/<HospitalController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(_context.Hospitals.SingleOrDefault(item => item.Id == id));
        }

        // POST api/<HospitalController>
        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Hospital hospital)
        {
            if (!_context.Hospitals.Contains(hospital))
            {
                _context.Hospitals.Add(hospital);
                await _context.SaveChangesAsync();
                return new JsonResult(hospital);
            }
            else
            {
                return new JsonResult(new { error = "This person is in the database", hospitalId = hospital.Id });
            }
        }

        // PUT api/<HospitalController>/5
        [HttpPut("{id}")]
        public async Task<JsonResult> Put(int id, [FromBody] Hospital hospital)
        {
            var hospitalUpdate = _context.Hospitals.SingleOrDefault(item => item == hospital);
            if (hospitalUpdate != null)
            {
                hospitalUpdate.PhoneNumber = hospital.PhoneNumber;
                hospitalUpdate.Schedule = hospital.Schedule;
                _context.Hospitals.Update(hospitalUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(hospitalUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This hospital is not in the database", personId = hospital.Id });
            }
        }

        // DELETE api/<HospitalController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            var hospitalUpdate = _context.Hospitals.SingleOrDefault(item => item.Id == id);
            if (hospitalUpdate != null)
            {
                _context.Hospitals.Remove(hospitalUpdate);
                await _context.SaveChangesAsync();
                return new JsonResult(hospitalUpdate);
            }
            else
            {
                return new JsonResult(new { error = "This pet is not in the database", hospitalId = id });
            }
        }
    }
}
