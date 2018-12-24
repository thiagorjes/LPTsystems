using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Medidor.Controllers
{
    [Route("medidor/[controller]")]
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
