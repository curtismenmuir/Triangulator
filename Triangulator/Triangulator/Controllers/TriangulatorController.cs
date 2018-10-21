using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triangulator.Lib;
using Triangulator.Models;

namespace Triangulator.Controllers
{
    [Route("api/[controller]")]
    public class TriangulatorController : ControllerBase
    {
        // GET api/triangulator/A5
        [HttpGet("{triangleName}")]
        public IEnumerable<string> GetCoordinates(string triangleName)
        {
            if (TriangleFunctions.VerifyTriangleName(triangleName.ToCharArray()))
            {
                Triangle triangle = new Triangle(triangleName);
                return new string[] { triangle.TriangleName, triangle.Coordinates };
            }
            else
            {
                return new string[] { "Invalid triangle" };
            }
        }
    }
}
