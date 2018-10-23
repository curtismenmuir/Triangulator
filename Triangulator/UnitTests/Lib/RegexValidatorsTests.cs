using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangulator.Lib;

namespace UnitTests.Lib
{
    [TestClass]
    public class RegexValidatorsTests
    {
        [TestMethod]
        public void ValidateLetterRegexTest()
        {
            char[] validCharacters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] invalidCharacters = new char[] { 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '@', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '[', '{', ']', '}', ';', ':', '#', '~', ',', '<', '.', '>', '/', '?' };

            foreach (var validChar in validCharacters)
            {
                Assert.IsTrue(RegexValidators.ValidateLetter(validChar));
            }
            foreach (var invalidChar in invalidCharacters)
            {
                Assert.IsFalse(RegexValidators.ValidateLetter(invalidChar));
            }
        }

        [TestMethod]
        public void Validate1stNumberRegexTest()
        {
            char[] validCharacters = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] invalidCharacters = new char[] { '0', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '@', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '[', '{', ']', '}', ';', ':', '#', '~', ',', '<', '.', '>', '/', '?' };

            foreach (var validChar in validCharacters)
            {
                Assert.IsTrue(RegexValidators.Validate1stNumber(validChar));
            }
            foreach (var invalidChar in invalidCharacters)
            {
                Assert.IsFalse(RegexValidators.Validate1stNumber(invalidChar));
            }
        }

        [TestMethod]
        public void Validate2ndNumberRegexTest()
        {
            char[] validCharacters = new char[] { '0', '1', '2' };
            char[] invalidCharacters = new char[] { '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '@', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '-', '=', '+', '[', '{', ']', '}', ';', ':', '#', '~', ',', '<', '.', '>', '/', '?' };

            foreach (var validChar in validCharacters)
            {
                Assert.IsTrue(RegexValidators.Validate2ndNumber(validChar));
            }
            foreach (var invalidChar in invalidCharacters)
            {
                Assert.IsFalse(RegexValidators.Validate2ndNumber(invalidChar));
            }
        }

        
        [TestMethod]
        public void ValidateCoordinateCharactersTest()
        {
            string[] validCoordinatesCharacters = new string[] { "0", "1", "2", "3", "4", "5", "6", "(", ")", "," };
            string[] invalidCoordinateCharacters = new string[] { "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "@", "!", "'", "£", "$", "%", "^", "&", "*", "_", "-", "=", "+", "[", "{", "]", "}", ";", ":", "#", "~", "<", ".", ">", "/", "?" };
            
            foreach (var coordinate in validCoordinatesCharacters)
            {
                Assert.IsTrue(RegexValidators.ValidateCoordinateCharacters(coordinate));
            }

            foreach(var coordinate in invalidCoordinateCharacters)
            {
                Assert.IsFalse(RegexValidators.ValidateCoordinateCharacters(coordinate));
            }
        }
        
    }
}
