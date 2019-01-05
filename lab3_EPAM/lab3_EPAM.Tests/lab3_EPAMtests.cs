using lab3_EPAM;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab3_EPAM.Tests
{
    [TestClass()]
    public class lab3_EPAMtests
    {
        [TestMethod()]
        public void nodBigInputTest_10and20and30_10returned()
        {
            // arrange
            int x = 10;
            int y = 20;
            int z = 30;
            int expected = 10;

            // act
            int actual = Nod.nodBigInput(x, y, z);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void binaryNod_10and20_10returned()
        {
            // arrange
            int x = 10;
            int y = 20;
            int expected = 10;

            // act
            int actual = Nod.binaryNod(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void nod_10and20_10returned()
        {
            // arrange
            int x = 10;
            int y = 20;
            int expected = 10;

            // act
            int actual = Nod.nod(x, y);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
