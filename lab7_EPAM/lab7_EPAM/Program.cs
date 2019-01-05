using System;
using System.Text;

namespace lab7_epam
{
    public class MatrixOutOfRangeException : Exception
    {
        private string augmented_message;

        public string additional => (augmented_message == null) ? "Дополнительной информации нет" : augmented_message; // геттер

        public MatrixOutOfRangeException(string message) : base(message) { }
        public MatrixOutOfRangeException(string message, int lines1, int columns1, int lines2, int columns2) : base(message)
        { augmented_message = "\n Количество строк: \n в первой матрице - " + lines1 + "\n во второй матрице - " + lines2 + "\n Количество столбцов: \n в первой матрице - " + columns1 + "\n во второй матрице - " + columns2; }
    }

    public class Matrix
    {
        Random rand = new Random();
        private double[,] matrix;
        public int lines;
        public int columns;

        public double this[int i, int j]
        {
            set
            {
                matrix[i, j] = value;
            }

            get
            {
                return matrix[i, j];
            }
        }

        public Matrix(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            matrix = new double[lines, columns];
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(10);
                }
            }
        }

        public Matrix GetEmpty(int lines, int columns)
        {
            Matrix newMatrix = new Matrix(lines, columns);

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newMatrix[i, j] = 0;
                }
            }
            return newMatrix;
        }

        public static Matrix sum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.lines != matrix2.lines | matrix1.columns != matrix2.columns)
            {
                throw new MatrixOutOfRangeException("Матрицы имеют разные размеры", matrix1.lines, matrix1.columns, matrix2.lines, matrix2.columns);
                //throw new MatrixOutOfRangeException("ghj");
            }

            Matrix result = new Matrix(matrix1.lines, matrix2.columns);
            for (int i = 0; i < result.lines; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix deduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.lines != matrix2.lines | matrix1.columns != matrix2.columns)
            {
                throw new MatrixOutOfRangeException("Матрицы имеют разные размеры", matrix1.lines, matrix1.columns, matrix2.lines, matrix2.columns);
            }

            Matrix result = new Matrix(matrix1.lines, matrix2.columns);
            for (int i = 0; i < result.lines; i++)
            {
                for (int j = 0; j < result.columns; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        public static Matrix mult(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.columns != matrix2.lines)
            {
                throw new MatrixOutOfRangeException("Невозможно перемножить матрицы данных размеров");
            }

            Matrix temp = new Matrix(matrix1.lines, matrix2.columns);
            for (int i = 0; i < matrix1.lines; ++i)
            {
                for (int j = 0; j < matrix2.columns; ++j)
                {
                    temp[i, j] = 0;
                    for (int k = 0; k < matrix1.columns; ++k)
                    {
                        temp[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return temp;
        }

        public string printMatrix()
        {
            StringBuilder str = new StringBuilder();

            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    str.Append(matrix[i, j] + " ");
                }
                str.AppendLine();
            }
            return str.ToString();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(3, 2);
            Matrix matrix2 = new Matrix(2, 3);
            Matrix matrix3;

            Matrix matrix4 = new Matrix(2, 2);
            System.Threading.Thread.Sleep(1000);
            Matrix matrix5 = new Matrix(2, 3);
            Matrix matrix6;

            try
            {
                matrix3 = Matrix.mult(matrix1, matrix2);
                Console.WriteLine("Первая матрица");
                Console.WriteLine(matrix1.printMatrix());
                Console.WriteLine("Вторая матрица");
                Console.WriteLine(matrix2.printMatrix());
                Console.WriteLine("Произведение");
                Console.WriteLine(matrix3.printMatrix());

                matrix6 = Matrix.deduct(matrix4, matrix5);
                Console.WriteLine("Первая матрица");
                Console.WriteLine(matrix4.printMatrix());
                Console.WriteLine("Вторая матрица");
                Console.WriteLine(matrix5.printMatrix());
                Console.WriteLine("Разность");
                Console.WriteLine(matrix6.printMatrix());

                matrix6 = Matrix.sum(matrix4, matrix5);
                Console.WriteLine("Первая матрица");
                Console.WriteLine(matrix4.printMatrix());
                Console.WriteLine("Вторая матрица");
                Console.WriteLine(matrix5.printMatrix());
                Console.WriteLine("Сумма");
                Console.WriteLine(matrix6.printMatrix());

            }
            catch (MatrixOutOfRangeException e)
            {
                e = new MatrixOutOfRangeException(e.Message + "      " + e.additional);
                Console.WriteLine(e);
            }
            Console.ReadKey();

        }
    }
}