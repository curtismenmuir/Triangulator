using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangulator.Controllers;

namespace UnitTests
{
    [TestClass]
    public class TriangluatorControllerTests
    {
        [TestMethod]
        public void GetCoordinatesTest()
        {
            string[] validTriangleNames = new string[] { "a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8", "a9", "a10", "a11", "a12",
                                                         "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8", "b9", "b10", "b11", "b12",
                                                         "c1", "c2", "c3", "c4", "c5", "c6", "c7", "c8", "c9", "c10", "c11", "c12",
                                                         "d1", "d2", "d3", "d4", "d5", "d6", "d7", "d8", "d9", "d10", "d11", "d12",
                                                         "e1", "e2", "e3", "e4", "e5", "e6", "e7", "e8", "e9", "e10", "e11", "e12",
                                                         "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "f10", "f11", "f12",
                                                         "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "A9", "A10", "A11", "A12",
                                                         "B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10", "B11", "B12",
                                                         "C1", "C2", "C3", "C4", "C5", "C6", "C7", "C8", "C9", "C10", "C11", "C12",
                                                         "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9", "D10", "D11", "D12",
                                                         "E1", "E2", "E3", "E4", "E5", "E6", "E7", "E8", "E9", "E10", "E11", "E12",
                                                         "F1", "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" };

            string[] invalidTriangleNames = new string[] { "g1", "g2", "g3", "g4", "g5", "g6", "g7", "g8", "g9", "g10", "g11", "g12",
                                                           "G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "G10", "G11", "G12",
                                                           "A", "ab", "ABC", "a111", "1A1", "1a", "11A", "aa1", "A00", "a01", "AAA",
                                                           "b", "BC", "bcd", "B111", "1b1", "1B", "11b", "BB1", "b00", "B01", "bbb",
                                                           "C", "cd", "CDE", "c111", "1C1", "1c", "11C", "cc1", "C00", "c01", "CCC",
                                                           "d", "DE", "def", "D111", "1d1", "1D", "11d", "DD1", "d00", "D01", "ddd",
                                                           "E", "eB", "EFG", "e111", "1E1", "1e", "11E", "ee1", "E00", "e01", "EEE",
                                                           "f", "FG", "fgh", "F111", "1f1", "1F", "11f", "FF1", "f00", "F01", "fff",
                                                           "A0", "a13", "B0", "b13", "C0", "c13", "D0", "d13", "E0", "e13", "F0", "f13" };

            foreach (var validTriangleName in validTriangleNames)
            {
                var temp = new TriangulatorController();
                string result = temp.GetCoordinates(validTriangleName);
                Assert.IsTrue(result.Equals("Valid triangle"));
            }

            foreach (var invalidTriangleName in invalidTriangleNames)
            {
                var temp = new TriangulatorController();
                string result = temp.GetCoordinates(invalidTriangleName);
                Assert.IsTrue(result.Equals("Invalid triangle"));
            }
        }
    }
}
