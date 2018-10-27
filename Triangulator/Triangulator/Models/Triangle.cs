using Triangulator.Lib;

namespace Triangulator.Models
{
    public class Triangle
    {
        public string TriangleName { get; private set; }
        public string Coordinates { get; private set; }

        /// <summary>
        /// Generates a Triangle from a valid TriangleName or valid set of Coordinates
        /// </summary>
        /// <param name="input"></param>
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
