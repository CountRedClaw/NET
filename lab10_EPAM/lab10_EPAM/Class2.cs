using System;

namespace lab10_EPAM
{
    /// <summary>
    /// Обрабатывает события при помощи анонимных делегатов
    /// </summary>
    public class Class2 : ICutDownNotifier
    {
        private Timer timer;
        private StartHandler del;
        private Action<String, String> timeOver;

        public Class2(String name, StartHandler callback, Action<String, String> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += delegate(object Sender, String name, String time)
            {
                del(Sender, name, time);
            };
            timer.onTimeLeft += delegate(object Sender, MyEventArgs myEventArgs)
            {
                Console.WriteLine("Осталось " + myEventArgs.Value + " секунд.");
            };
            timer.onStop += delegate(object Sender, String name, int time)
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