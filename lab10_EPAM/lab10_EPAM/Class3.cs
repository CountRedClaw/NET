using System;

namespace lab10_EPAM
{
    /// <summary>
    /// <summary>
    /// Обрабатывает события при помощи лямбда выражений
    /// </summary>
    public class Class3 : ICutDownNotifier
    {
        private Timer timer;
        private StartHandler del;
        private Action<String, String> timeOver;

        public Class3(String name, StartHandler callback, Action<String, String> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += (object Sender, String name, String time) =>
            {
                del(Sender, name, time);
            };
            timer.onTimeLeft += (object Sender, MyEventArgs myEventArgs) => 
            {
                Console.WriteLine("Осталось " + myEventArgs.Value + " секунд.");
            };
            timer.onStop += (object Sender, String name, int time) =>
            {
                timeOver(name, time.ToString());
            };
        }

        public void Run()
        {
            timer.Count();
        }
    }
}