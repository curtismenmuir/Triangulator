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
    } 
}
