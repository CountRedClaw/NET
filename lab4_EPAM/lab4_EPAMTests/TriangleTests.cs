using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4_EPAM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_EPAM.Tests
{
    [TestClass()]
    public class TriangleTests
    {
        [TestMethod()]
        public void areaTest()
        {
            // arrange
            double x = 3;
            double y = 4;
            double z = 5;
            double expected = 6;
            Triangle tr = new Triangle(x, y, z);

            // act
            double actual = tr.area();

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void perimeterTest()
        {
            // arrange
            double x = 3;
            double y = 4;
            double z = 5;
            double expected = 12;
            Triangle tr = new Triangle(x, y, z);

            // act
            double actual = tr.perimeter();

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}