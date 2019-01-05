using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab7_epam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_epam.Tests
{
    [TestClass()]
    public class MatrixTests
    {
        [TestMethod()]
        public void sumTest()
        {
            // arrange
            Matrix expected = new Matrix(2, 2);
            Matrix first = new Matrix(2, 2);
            Matrix second = new Matrix(2, 2);
            Matrix actual;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    first[i, j] = 2;
                    second[i, j] = 2;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    expected[i, j] = 4;
                }
            }
            // act
            actual = Matrix.sum(first, second);

            // assert
            Assert.AreEqual(expected.printMatrix(), actual.printMatrix());
        }
        [TestMethod()]
        public void deductTest()
        {
            // arrange
            Matrix expected = new Matrix(2, 2);
            Matrix first = new Matrix(2, 2);
            Matrix second = new Matrix(2, 2);
            Matrix actual;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    first[i, j] = 3;
                    second[i, j] = 1;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    expected[i, j] = 2;
                }
            }
            // act
            actual = Matrix.deduct(first, second);

            // assert
            Assert.AreEqual(expected.printMatrix(), actual.printMatrix());
        }
        [TestMethod()]
        public void multTest()
        {
            // arrange
            Matrix expected = new Matrix(2, 2);
            Matrix first = new Matrix(2, 2);
            Matrix second = new Matrix(2, 2);
            Matrix actual;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    first[i, j] = 1;
                    second[i, j] = 1;
                }
            }
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    expected[i, j] = 2;
                }
            }
            // act
            actual = Matrix.mult(first, second);

            // assert
            Assert.AreEqual(expected.printMatrix(), actual.printMatrix());
        }
    }
}