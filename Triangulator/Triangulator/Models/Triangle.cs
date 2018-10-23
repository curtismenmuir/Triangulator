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

        public Triangle(string input)
        {
            if (input.Length < 4)
            {
                this.TriangleName = input;
                this.Coordinates = TriangleFunctions.GenerateCoordinates(input.ToCharArray());
            }
            else
            {
                this.Coordinates = input;
                this.TriangleName = TriangleFunctions.GenerateTriangleName(input);
            }
        }
    }
}
