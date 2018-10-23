using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triangulator.Lib;
using Triangulator.Models;

namespace Triangulator.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TriangulatorController : ControllerBase
    {
        // GET api/triangulator/GetCoordinates/A5
        [HttpGet("{triangleName}")]
        public ActionResult GetCoordinates(string triangleName) //ActionResult
        {
            if (TriangleFunctions.VerifyTriangleName(triangleName.ToCharArray()))
            {
                Triangle triangle = new Triangle(triangleName);
                return Ok(triangle);
            }
            else
            {
                return BadRequest("Invalid Triangle Name");
            }
        }
        

        // GET api/triangulator/GetTriangleName/(0,10),(0,0),(10,10)
        [HttpGet("{coordinates}")]
        public ActionResult GetTriangleName(string coordinates)
        {
            if (TriangleFunctions.VerifyCoordinates(coordinates))
            {
                Triangle triangle = new Triangle(coordinates);
                return Ok(triangle);
            }
            else
            {
                return BadRequest("Invalid Triangle Coordinates");
            }
        }
    }
}
