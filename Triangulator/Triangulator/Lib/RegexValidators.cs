using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Triangulator.Lib
{
    public static class RegexValidators
    {
        public static bool ValidateLetter(char letter)
        {
            return Regex.IsMatch(letter.ToString(), @"^[a-fA-F]+$"); // Regex for letters a-f
        }

        public static bool Validate1stNumber(char number)
        {
            return Regex.IsMatch(number.ToString(), @"^[1-9]+$"); // Regex for numbers 1-9
        }

        public static bool Validate2ndNumber(char number)
        {
            return Regex.IsMatch(number.ToString(), @"^[0-2]+$"); // Regex for numbers 0-2 
        }
        public static bool ValidateCoordinates(string coordinate)
        {
            return Regex.IsMatch(coordinate, @"^[0-6,()]+$"); // Regex for numbers 1-9
        }
    }
}
