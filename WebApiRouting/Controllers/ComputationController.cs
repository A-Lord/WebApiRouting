using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRouting.Controllers
{
    [Route("compute")]
    [ApiController]
    public class ComputationController : ControllerBase
    {
        [HttpGet("message")]
        public string Message(string myMessage)
        {
            return $"Ditt meddeland är: {myMessage}";
        }
        [HttpGet("upper/{input}")]
        public string Upper(string input)
        {
            string upperReturn = input.ToUpper();
            return upperReturn;
        }
        [HttpGet("concat/{message1}")]
        public string Concat(string message1,[FromQuery] string message2)
        {
            return $"{message1}{message2}";
        }
        [HttpGet("add")]
        public string Add([FromQuery] int first,[FromQuery] int second)
        {
            string returner = (first + second).ToString();
            return returner;
        }
        [HttpGet("add2/{first}/{second}")]
        public string Add2(int first,int second)
        {
            string returner = (first + second).ToString();
            return returner;
        }
        [HttpGet("multi")]
        public string MultiGreeter([FromQuery]int count,[FromQuery] string message)
        {
            string multiGreeter = "";
            for (int i = 0; i < count; i++)
            {
                multiGreeter += " " + message;
            }
            return multiGreeter;
        }
        [HttpGet("multi2/{count}/{message}")]
        public string MultiGreeter2(int count,string message)
        {
            string multiGreeter = "";
            for (int i = 0; i < count; i++)
            {
                multiGreeter += " " + message;
            }
            return multiGreeter;
        }
        [HttpPost("execute")]
        public int Compute(ComputeUnit computeUnite)
        {
            return computeUnite.Compute();
        }

        [HttpPost("multiexecute")]
        public int MultiCompute([FromQuery]int count,[FromBody] ComputeUnit cUnite)
        {
            int sendBackInt = 0;
            for (int i = 0; i < count; i++)
            {
                sendBackInt += cUnite.Compute();
            }
            return sendBackInt;
        }
        [HttpGet("create-addition")]
        public ComputeUnit CreateAdditionComputation([FromQuery]int value1,[FromQuery]int value2)
        {
            ComputeUnit addition = new ComputeUnit(value1, value2);
            addition.Mode = "addition";
            return addition;
        }
        [HttpPost("change-mode")]
        public ComputeUnit ChangeMode(ComputeUnit changeCompUnit, [FromRoute] string newMode)
        {
            changeCompUnit.Mode = newMode;
            return changeCompUnit;
        }

    }
}
