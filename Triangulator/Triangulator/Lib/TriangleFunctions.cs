using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triangulator.Lib
{
    public static class TriangleFunctions
    {
        public static bool VerifyTriangleName(char[] triangleName)
        {
            if (triangleName.Count() > 1 && triangleName.Count() < 4)
            {
                if (RegexValidators.ValidateLetter(triangleName[0]) && RegexValidators.Validate1stNumber(triangleName[1]))
                {
                    if (triangleName.Count() == 2 || RegexValidators.Validate2ndNumber(triangleName[2]))
                    {
                        return true;
                    }   
                }
            }
            return false;
        }

        public static string GenerateCoordinates(char[] triangleName)
        {
            int maxX;
            int maxY = ConvertLetterToNumber(triangleName[0]) * 10; // convert letter to number (eg A to 1) and multiply by 10 to get maxX value of coordinate
            int mod;

            if (triangleName.Count() == 2)
            {
                Int32.TryParse(triangleName[1].ToString(), out maxX);
                mod = maxX % 2;
            }
            else
            {
                Int32.TryParse(triangleName[2].ToString(), out maxX);
                mod = maxX % 2;
                maxX = maxX + 10; // Add 10 to maxX to make it 10 / 11 / 12 - only last char in int from parse above
            }
            
            if (mod == 1) // triangle below (odd)
            {
                maxX = (maxX + 1) * 5;
                return "(" + (maxX - 10).ToString() + "," + maxY.ToString() + "),(" + (maxX - 10).ToString() + "," + (maxY - 10).ToString() + "),(" + maxX.ToString() + "," + maxY.ToString() + ")";
            }
            else // triangle above (even)
            {
                maxX = maxX * 5;
                return "(" + maxX.ToString() + "," + (maxY - 10).ToString() + "),(" + (maxX - 10).ToString() + "," + (maxY - 10).ToString() + "),(" + maxX.ToString() + "," + maxY.ToString() + ")";
            }
        }

        public static int ConvertLetterToNumber(char letter)
        {
            return Char.ToUpper(letter) - 64; // Uppercase A-F map to int values 65-70
        }
    } 
}
