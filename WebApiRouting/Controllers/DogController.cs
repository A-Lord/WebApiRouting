using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRouting.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        [HttpPost("pet")]
        public IActionResult Pet(Dog dog)
        {
            if (dog.HappinessLEvel == "")
            {
                dog.HappinessLEvel = "happy";
                return Ok(dog);
            }
            else if (dog.HappinessLEvel == "happy")
            {
                dog.HappinessLEvel = "very happy";
                return Ok(dog);
            }
            return NotFound();
        }
        [HttpPost("kick")]
        public IActionResult Kick([FromBody]Dog dog)
        {
            return BadRequest();
        }
        [HttpPost("find-sock")]
        public IActionResult FindSock([FromBody]Dog dog)
        {
            if (dog.HappinessLEvel == "very happy")
            {
                return NotFound();
            }
            else
            {
                return Ok("Sock found");
            }
        }
    }
}
