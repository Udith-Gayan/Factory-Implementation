using Factory_Implementation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Factory_Implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISimpleService _service;

        public TestController(ISimpleService service)
        {
            _service = service;
        }

        // GET api/<TestController>/5
        [HttpGet("{message}")]
        public async Task<IActionResult> Get(string message)
        {
            await _service.WriteMessageAsync(message);
            return Ok();
        }

        // DELETE api/<TestController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            await _service.ClearLogFiles();
            return Ok();
        }
    }
}
