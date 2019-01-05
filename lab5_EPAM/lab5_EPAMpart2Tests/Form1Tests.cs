using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab5_EPAMpart2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_EPAMpart2.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void subtractionTest()
        {
            // arrange
            Polynomial expected = new Polynomial("4x-6y");
            Polynomial first = new Polynomial("3x-4y");
            Polynomial second = new Polynomial("-x+2y");
            Polynomial actual;

            // act
            actual = first - second;

            // assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void sumTest()
        {
            // arrange
            Polynomial expected = new Polynomial("2x-2y");
            Polynomial first = new Polynomial("3x-4y");
            Polynomial second = new Polynomial("-x+2y");
            Polynomial actual;

            // act
            actual = first + second;

            // assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}