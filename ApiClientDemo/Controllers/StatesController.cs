using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiClientDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        List<string> states = new(new string[] { "State 1", "State 2", "State 3", "State 4" });

        // GET api/States
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return states;
        }

        // GET api/States/1
        [HttpGet("{index}")]
        public string Get(int index)
        {
            return index > states.Count - 1 ? "Index out of bounds. Specify a lower index" : states[index];
        }

        // POST api/States
        [HttpPost]
        public string Post([FromBody] string value)
        {
            states.Add(value);
            return $"The state {value} was successfully added but not persisted by design.";
        }

        // DELETE api/States/State 2
        [HttpDelete("{state}")]
        public string Delete(string state)
        {
            states.Remove(state);
            return $"The state {state} was successfully removed but not persisted by design.";
        }
    }
}
