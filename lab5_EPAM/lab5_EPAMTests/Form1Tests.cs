using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab5_EPAM.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void sumTest()
        {
            // arrange
            double x = 3;
            double y = 4;
            double z = 5;
            Vector expected = new Vector(6, 8, 10);
            Vector first = new Vector(x, y, z);
            Vector second = new Vector(x, y, z);
            Vector actual;

            // act
            actual = first + second;

            // assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void subtractionTest()
        {
            // arrange
            double x = 3;
            double y = 4;
            double z = 5;
            Vector expected = new Vector(0, 0, 0);
            Vector first = new Vector(x, y, z);
            Vector second = new Vector(x, y, z);
            Vector actual;

            // act
            actual = first - second;

            // assert
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod()]
        public void scalarMultTest()
        {
            // arrange
            double x = 1;
            double y = 2;
            double z = 3;
            double expected = 14;
            Vector first = new Vector(x, y, z);
            Vector second = new Vector(x, y, z);
            double actual;

            // act
            actual = first * second;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}