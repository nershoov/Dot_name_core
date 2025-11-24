using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("random")]
        public ActionResult GetRandomNumber()
        {
            var random = new Random();
            return Ok(random.Next(1, 11));
        }

        [HttpGet("string")]
        public ActionResult GetCombinedString()
        {
            var hello = "Hello";
            var world = "World";
            var result = hello + " " + world;
            return Ok(result);
        }

        [HttpGet("multiply/{num}")]
        public ActionResult MultiplyByTwo(int num)
        {
            return Ok(num * 2);
        }

    }
}
