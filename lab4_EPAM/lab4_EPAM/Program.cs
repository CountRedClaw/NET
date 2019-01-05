using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_EPAM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class Triangle
    {
        private double a, b, c;
        public Triangle(double _a, double _b, double _c)
        {
            if ((_a + _b > _c) && (_a + _c > _b) && (_b + _c > _a)) {
                a = _a;
                b = _b;
                c = _c;
            }
            else { throw new Exception(); }
        }
        /// <summary>
        /// Вычисление площади по формуле Герона
        /// </summary>
        /// <returns></returns>
        public double area()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        /// <summary>
        /// Периметр находится как сумма всех сторон
        /// </summary>
        /// <returns></returns>
        public double perimeter()
        {
            return a + b + c;
        }
    }
}
