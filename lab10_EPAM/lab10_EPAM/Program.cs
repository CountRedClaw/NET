using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_EPAM
{
    public delegate void StartHandler(object Sender, String name, String time);
    public delegate void TimeLeftHandler(object sender, MyEventArgs e);
    public delegate void StopHandler(object sender, String name, int time);
    
    class Program
    {
        static void Main(string[] args)
        {
            StartHandler del = Start;
            Action<String, String> timeOver = TimeOver;

            ICutDownNotifier[] classes = new ICutDownNotifier[] { new Class1("Чтение задания", del, timeOver),
                                                                  new Class2("Выполнение задания", del, timeOver),
                                                                  new Class3("Проверка задания перед отправкой", del, timeOver) };

            foreach (var cl in classes)
            {
                cl.Init();
                cl.Run();
            }

            Console.ReadKey();
        }

        static void Start(object Sender, String taskName, String time)
        {
            Console.WriteLine("Старт обратного отсчёта. Название задачи: " + taskName + ". Времени отведено: " + time + " (Источник события - " + Sender + ")");
        }

        static void TimeOver(String taskName, String time)
        {
            Console.WriteLine("Обратный отсчёт завершён. Название задачи: " + taskName + ". Времени было отведено: " + time);
        }
    }
}
