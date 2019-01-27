using BabysitterKata.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BabysitterKata.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabysitterController : ControllerBase
    {
        // GET: api/Babysitter
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Babysitter/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Babysitter
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Babysitter/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
