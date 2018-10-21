using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triangulator.Lib
{
    public static class TriangleFunctions
    {
        private const int minMaxTriangleCoordinates = 6;
        
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

        public static bool VerifyCoordinates(string coordinates)
        {
            if (RegexValidators.ValidateCoordinates(coordinates))
            {
                coordinates = coordinates.Replace("(", string.Empty);
                coordinates = coordinates.Replace(")", string.Empty);

                string[] splitCoordinates = coordinates.Split(',');

                if (splitCoordinates.Length != minMaxTriangleCoordinates)
                {
                    return false;
                }

                int[] convertedCoordinates = new int[splitCoordinates.Length];

                for (int i = 0; i < splitCoordinates.Length; i++)
                {
                    Int32.TryParse(splitCoordinates[i], out convertedCoordinates[i]);
                }
                
                int maxX = Math.Max(convertedCoordinates[0], Math.Max(convertedCoordinates[2], convertedCoordinates[4]));
                
                // Check if odd triangle (eg A1, A3)
                if ((convertedCoordinates[0] == maxX && convertedCoordinates[2] != maxX && convertedCoordinates[4] != maxX) ||
                    (convertedCoordinates[0] != maxX && convertedCoordinates[2] == maxX && convertedCoordinates[4] != maxX) ||
                    (convertedCoordinates[0] != maxX && convertedCoordinates[2] != maxX && convertedCoordinates[4] == maxX)) 
                {
                    // validate X coordinates
                    if (convertedCoordinates[0] == convertedCoordinates[2] || convertedCoordinates[0] == convertedCoordinates[4]) // if X1 == X2 or X3
                    {
                        if (!(convertedCoordinates[2] == (convertedCoordinates[0] + 10)) && !(convertedCoordinates[4] == (convertedCoordinates[0] + 10))) // if (X1 + 10) != X2 or X3 then invalid
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!(convertedCoordinates[2] == convertedCoordinates[4]) || !(convertedCoordinates[0] == (convertedCoordinates[2] + 10))) // if X2 != X3 OR X1 != (X2 + 10) then invalid
                        {
                            return false;
                        }
                    }

                    // validate Y coordinates
                    if (convertedCoordinates[1] == convertedCoordinates[3] || convertedCoordinates[1] == convertedCoordinates[5]) // if Y1 == Y2 or Y3
                    {
                        if (!(convertedCoordinates[3] == (convertedCoordinates[1] - 10)) && !(convertedCoordinates[5] == (convertedCoordinates[1] - 10))) // if (Y1 - 10) != Y2 or Y3 then invalid
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!(convertedCoordinates[3] == convertedCoordinates[5]) || !(convertedCoordinates[1] == (convertedCoordinates[3] - 10))) // if Y2 != Y3 OR Y1 != (Y2 - 10) then invalid
                        {
                            return false;
                        }
                    }

                }
                else // Else even triangle (eg A2, A6)
                {
                    // validate X coordinates
                    if (convertedCoordinates[0] == convertedCoordinates[2] || convertedCoordinates[0] == convertedCoordinates[4]) // if X1 == X2 or X3
                    {
                        if (!(convertedCoordinates[2] == (convertedCoordinates[0] - 10)) && !(convertedCoordinates[4] == (convertedCoordinates[0] - 10))) // if (X1 - 10) != X2 or X3 then invalid
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!(convertedCoordinates[2] == convertedCoordinates[4]) || !(convertedCoordinates[0] == (convertedCoordinates[2] - 10))) // if X2 != X3 OR X1 != (X2 - 10) then invalid
                        {
                            return false;
                        }
                    }

                    // validate Y coordinates
                    if (convertedCoordinates[1] == convertedCoordinates[3] || convertedCoordinates[1] == convertedCoordinates[5]) // if Y1 == Y2 or Y3
                    {
                        if (!(convertedCoordinates[3] == (convertedCoordinates[1] + 10)) && !(convertedCoordinates[5] == (convertedCoordinates[1] + 10))) // if (Y1 + 10) != Y2 or Y3 then invalid
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (!(convertedCoordinates[3] == convertedCoordinates[5]) || !(convertedCoordinates[1] == (convertedCoordinates[3] + 10))) // if Y2 != Y3 OR Y1 != (Y2 + 10) then invalid
                        {
                            return false;
                        }
                    }
                }
                return true;
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
                mod = maxX % 2; // mod by 2 to check if odd or even number
            }
            else
            {
                Int32.TryParse(triangleName[2].ToString(), out maxX);
                mod = maxX % 2; // mod by 2 to check if odd or even number
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

        public static string GenerateTriangleName(string coordinates)
        {
            coordinates = coordinates.Replace("(", string.Empty);
            coordinates = coordinates.Replace(")", string.Empty);

            string[] splitCoordinates = coordinates.Split(',');

            int[] convertedCoordinates = new int[splitCoordinates.Length];

            for (int i = 0; i < splitCoordinates.Length; i++)
            {
                Int32.TryParse(splitCoordinates[i], out convertedCoordinates[i]);
            }
            
            int maxX = Math.Max(convertedCoordinates[0], Math.Max(convertedCoordinates[2], convertedCoordinates[4]));
            int maxY = Math.Max(convertedCoordinates[1], Math.Max(convertedCoordinates[3], convertedCoordinates[5]));
            
            char rowLetter = ConvertNumberToLetter(maxY);

            int columnNumber = maxX / 5;

            if((convertedCoordinates[0] == maxX && convertedCoordinates[2] != maxX && convertedCoordinates[4] != maxX) ||
                (convertedCoordinates[0] != maxX && convertedCoordinates[2] == maxX && convertedCoordinates[4] != maxX) ||
                (convertedCoordinates[0] != maxX && convertedCoordinates[2] != maxX && convertedCoordinates[4] == maxX))
            {
                columnNumber = columnNumber - 1;
            }

            return rowLetter + columnNumber.ToString();
        }

        public static int ConvertLetterToNumber(char letter)
        {
            return Char.ToUpper(letter) - 64; // Minus 64 to convert A-F (CAPS) to 1-6
        }

        public static char ConvertNumberToLetter(int num)
        {
            num = (num / 10) + 64; // Add 64 to convert 1-6 to A-F
            return (char) num;
        }
    } 
}
