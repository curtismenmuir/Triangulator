using Microsoft.AspNetCore.Mvc;
using Triangulator.Lib;
using Triangulator.Models;

namespace Triangulator.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TriangulatorController : ControllerBase
    {
        /// <summary>
        /// API Controller which generates the triangle coordinates from a triangleName.
        /// Usage: GET ../api/triangulator/GetCoordinates/A5
        /// </summary>
        /// <param name="triangleName"></param>
        /// <returns>Result(Triangle)</returns>
        [HttpGet("{triangleName}")]
        public ActionResult GetCoordinates(string triangleName)
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

        /// <summary>
        /// API Controller which generates the triangle name from a set of coordinates
        /// Usgae: GET ../api/triangulator/GetTriangleName/(0,10),(0,0),(10,10)
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>Result(Triangle)</returns>
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
