using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ServidorDeDados.Controllers
{
    [Route("LPT/[controller]")]
    [ApiController]
    public class RunningController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Running", "Ok" };
        }
    }
}
