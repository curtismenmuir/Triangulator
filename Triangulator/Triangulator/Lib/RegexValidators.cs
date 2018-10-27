using System.Text.RegularExpressions;

namespace Triangulator.Lib
{
    public static class RegexValidators
    {
        /// <summary>
        /// Verifies that the letter used in a TriangleName is in the range of a-f / A-F
        /// </summary>
        /// <param name="letter"></param>
        /// <returns>True / False</returns>
        public static bool ValidateLetter(char letter)
        {
            return Regex.IsMatch(letter.ToString(), @"^[a-fA-F]+$");
        }

        /// <summary>
        /// Verifies that the 1st number used in a TriangleName is in the range of 1-9
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True / False</returns>
        public static bool Validate1stNumber(char number)
        {
            return Regex.IsMatch(number.ToString(), @"^[1-9]+$");
        }

        /// <summary>
        /// Verifies that the 2nd number used in a TriangleName is in the range of 0-2
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True / False</returns>
        public static bool Validate2ndNumber(char number)
        {
            return Regex.IsMatch(number.ToString(), @"^[0-2]+$");
        }

        /// <summary>
        /// Verifies that a set of coordinates contain only the numbers 0-6 as well as the following characters ( ) ,
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns>True / False</returns>
        public static bool ValidateCoordinateCharacters(string coordinate)
        {
            return Regex.IsMatch(coordinate, @"^[0-6,()]+$");
        }
    }
}
