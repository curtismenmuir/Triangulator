using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Triangulator.Controllers
{
    [Route("api/[controller]")]
    public class TriangulatorController : ControllerBase
    {
        // GET: api/triangulator
        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
