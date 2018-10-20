using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangulator.Controllers;

namespace UnitTests
{
    [TestClass]
    public class TriangluatorControllerTests
    {
        [TestMethod]
        public void TestGet()
        {
            var temp = new TriangulatorController();
            string result = temp.Get();
            Assert.IsTrue(result.Equals("Hello World"));
        }
    }
}
