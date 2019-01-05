using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_EPAM
{
    class Program
    {
        static void Main(string[] args)
        {
            double number, accuracy;
            int power;
            Console.WriteLine("Введите число для вычисления корня, степень и необходимую точность");
            number = double.Parse(Console.ReadLine());
            power = int.Parse(Console.ReadLine());
            accuracy = double.Parse(Console.ReadLine());
            int i = 0;
            do
            {
                Console.Write("Меню:\n1) Вычислить корень \n2) Выйти из программы\n\n: ");
                try
                {
                    i = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { }
                switch (i)
                {
                    case 1:
                        Console.WriteLine("Вычисление методом Ньютона");
                        Console.WriteLine(Root.CalcRootWithoutMath(number, power, accuracy));
                        
                        Console.WriteLine("Вычисление при помощи Math.Pow");
                        Console.WriteLine(Root.CalcRoot(number, power));
                        if (Root.CompareResults()) { Console.WriteLine("Результаты одинаковы"); } else { Console.WriteLine("Результаты разные"); };
                        break;
                    case 2:
                        break;
                    default:
                        Console.WriteLine("Это ни на что не похоже...");
                        break;
                }
                Console.Write("\n\n\t\t\tНажмите любую клавишу...");
                Console.ReadLine();
                Console.Clear();
            }
            while (i != 2);
        }        
    }
    
    public class Root
    {
        static double result1, result2;
        static double Pow(double a, int pow)
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }

        public static double CalcRoot(double number, int power)
        {
            double result = Math.Pow(number, (1.0 / power));
            result1 = result;
            return result;
        }
        public static double CalcRootWithoutMath(double number, int power, double accuracy)
        {
            if (number == 0) return 0;
            double x = 0, result = 1;
            do
            {
                x = result;
                result = ((power - 1) * x + number / Math.Pow(x, power - 1)) / power;

            } while (Math.Abs(x - result) > accuracy);
            result2 = result;
            return result;
        }
        public static Boolean CompareResults()
        {
            return (result1 - result2 == 0) ? true : false;
        }        
    }
}
