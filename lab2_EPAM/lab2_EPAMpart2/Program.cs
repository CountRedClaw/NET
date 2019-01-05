using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_EPAMpart2
{
    class Program
    {
        static void Main(string[] args)
        {
            int value;
            int i = 0;
            do
            {
                Console.Write("Меню:\n1) Перевести в двоичную систему счисления \n2) Выйти из программы\n\n: ");
            try
            {
                i = int.Parse(Console.ReadLine());
            }
            catch (Exception e) { }
            switch (i)
            {
                case 1:
                    Console.WriteLine("Введите число для перевода в двоичную систему счисления");
                    value = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введенное число в двоичной системе выглядит следующим образом: " + Converter.ToBinary(value) + " (При помощи стандартных средств языка)");
                        Console.WriteLine("Без стандартных средств языка: " + Converter.ToBinaryWithoutStandard(value));
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
    class Converter
    {
        public static string ToBinary(int value)
        {
            string binary = "";
            binary = Convert.ToString(value, 2);
            return binary;
        }
        public static string ToBinaryWithoutStandard(int value)
        {
            string binary = "";
            var stack = new Stack<int>();
            var result = new Stack<int>();
            while (value > 0)
            {
                stack.Push(value % 2);
                value /= 2;
            }
            string[] arr = stack.Select(i => i.ToString()).ToArray();
            binary = String.Join(null, arr);

            return binary;
        }
    }
}
