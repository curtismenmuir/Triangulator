using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triangulator.Lib;

namespace Triangulator.Models
{
    public class Triangle
    {
        public string TriangleName { get; private set; }
        public string Coordinates { get; private set; }

        public Triangle(string triangleName)
        {
            this.TriangleName = triangleName;
            this.Coordinates =  TriangleFunctions.GenerateCoordinates(TriangleName.ToCharArray());
        }
    }
}
