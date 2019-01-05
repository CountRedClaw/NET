using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace lab1_EPAM
{
    class Program
    {
        /// <summary>
        /// Меню
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            int i = 0;
            do
            {
                Console.Write("Меню:\n1) Ввести с клавиатуры \n2) Считать из файла 2\n3) Выйти из программы\n\n: ");
                try
                {
                    i = int.Parse(Console.ReadLine());
                }
                catch (Exception e) { }
                switch (i)
                {
                    case 1:
                        readFromKeyboard();
                        break;
                    case 2:
                        readFromFile();
                        break;
                    case 3:
                        break;
                    default:                        
                        Console.WriteLine("Это ни на что не похоже...");
                        break;
                }
                Console.Write("\n\n\t\t\tНажмите любую клавишу...");
                Console.ReadLine();
                Console.Clear();
            }
            while (i != 3);
        }
        /// <summary>
        /// Функция вызывается при нажатии кнопки 1 в главном меню
        /// Считывает с клавиатуры координаты и выводит их в файл и на экран
        /// </summary>
        static void readFromKeyboard()
        {
            // Пишем в "lab1_EPAM\lab1_EPAM\bin\Debug\output.txt"
            string writePath = @"output.txt";
            List<String> strings = new List<String>();
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            String str = "";
            Decimal val1, val2;
            Char delimiter = ',';

            ConsoleKeyInfo btn;

            try
            {
                do
                {
                    Console.WriteLine("Ввод: ");
                    str = Console.ReadLine();
                    strings.Add(str);
                    btn = Console.ReadKey();
                }
                while (btn.Key != ConsoleKey.Escape);

                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (String s in strings)
                    {
                        String[] substrings = s.Split(delimiter);
                        var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
                        val1 = Decimal.Parse(substrings[0], numberFormatInfo);
                        val2 = Decimal.Parse(substrings[1], numberFormatInfo);

                        Console.WriteLine("X: {0} Y: {1}", val1, val2);
                        sw.WriteLine("X: {0} Y: {1}", val1, val2);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Функция вызывается при нажатии кнопки 2 в главном меню
        /// Считывает из файла координаты и выводит их в файл и на экран
        /// </summary>
        static void readFromFile()
        {
            string path = @"file.txt";
            string writePath = @"output.txt";
            List<String> strings = new List<String>();
            String str = "";
            Decimal val1, val2;
            Char delimiter = ',';

            try
            {
                Console.WriteLine();
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strings.Add(line);
                        //Console.WriteLine(line);
                    }
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (String s in strings)
                    {
                        String[] substrings = s.Split(delimiter);
                        var numberFormatInfo = new NumberFormatInfo { NumberDecimalSeparator = "." };
                        val1 = Decimal.Parse(substrings[0], numberFormatInfo);
                        val2 = Decimal.Parse(substrings[1], numberFormatInfo);

                        Console.WriteLine("X: {0} Y: {1}", val1, val2);
                        sw.WriteLine("X: {0} Y: {1}", val1, val2);
                    }
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
