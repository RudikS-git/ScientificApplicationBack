using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceResearchPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InnovativeDevelopmentController : BaseApiController
    {
        // GET: api/<InnovativeDevelopmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InnovativeDevelopmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InnovativeDevelopmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InnovativeDevelopmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InnovativeDevelopmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
