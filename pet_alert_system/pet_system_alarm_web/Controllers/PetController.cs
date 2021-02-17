using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using pet_system_alarm_library.Models;
using pet_system_alarm_library.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace pet_system_alarm_web.Controllers
{
    [Route("[controller]")]
    public class PetController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        public PetController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("getpettype")]
        public async Task<JsonResult> GetPetType()
        {
            var client = _clientFactory.CreateClient();
            var getTypeResult = await client.GetAsync("https://localhost:5001/api/pet/getpettype");
            var result = JsonConvert.DeserializeObject<List<ArrayFormat>>(await getTypeResult.Content.ReadAsStringAsync());
            return new JsonResult(result);
        }

        [HttpGet("getpetcolor")]
        public async Task<JsonResult> GetPetColor()
        {
            var client = _clientFactory.CreateClient();
            var getTypeResult = await client.GetAsync("https://localhost:5001/api/pet/getpetcolor");
            var result = JsonConvert.DeserializeObject<List<ArrayFormat>>(await getTypeResult.Content.ReadAsStringAsync());
            return new JsonResult(result);
        }
        [HttpGet("getpetbyowner")]
        public async Task<JsonResult> GetPetByOwner()
        {
            int id = 2;
            var client = _clientFactory.CreateClient();
            var getTypeResult = await client.GetAsync("https://localhost:5001/api/pet/getpetbyowner/" + id);
            var result = JsonConvert.DeserializeObject<List<Pet>>(await getTypeResult.Content.ReadAsStringAsync());
            return new JsonResult(result);
        }
    }
}
