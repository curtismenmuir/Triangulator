using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Triangulator.Lib;

namespace Triangulator.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TriangulatorController : ControllerBase
    {
        // GET api/triangulator/GetCoordinates/A5
        [HttpGet("{triangleName}")]
        public IEnumerable<string> GetCoordinates(string triangleName)
        {
            if (TriangleFunctions.VerifyTriangleName(triangleName.ToCharArray()))
            {
                return new string[] { triangleName, TriangleFunctions.GenerateCoordinates(triangleName.ToCharArray()) };
            }
            else
            {
                return new string[] { "Invalid Triangle Name" };
            }
        }

        // GET api/triangulator/GetTriangleName/(0,10),(0,0),(10,10)
        [HttpGet("{coordinates}")]
        public IEnumerable<string> GetTriangleName(string coordinates)
        {
            if (TriangleFunctions.VerifyCoordinates(coordinates))
            {
                return new string[] { TriangleFunctions.GenerateTriangleName(coordinates), coordinates };
            }
            else
            {
                return new string[] { "Invalid Triangle Coordinates" };
            }
        }
    }
}
