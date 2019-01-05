using System;

namespace lab10_EPAM
{
    /// <summary>
    /// Обрабатывает события при помощи методов
    /// </summary>
    public class Class1 : ICutDownNotifier
    {
        private Timer timer;
        private StartHandler del;
        private Action<String, String> timeOver;


        public Class1(String name, StartHandler callback, Action<String, String> timeOver)
        {
            timer = new Timer(name);
            del = callback;
            this.timeOver = timeOver;
        }

        public void Init()
        {
            timer.onStart += Start;
            timer.onTimeLeft += TimeLeft;
            timer.onStop += Stop;
        }

        public void Run()
        {
            timer.Count();
        }

        private void Start(object Sender, String name, String time)
        {
            del(Sender, name, time);
        }

        private void TimeLeft(object Sender, MyEventArgs myEventArgs)
        {
            Console.WriteLine("Осталось " + myEventArgs.Value + " секунд.");
        }

        private void Stop(object Sender, String name, int time)
        {
            timeOver(name, time.ToString());
            //Console.WriteLine("Время вышло! Имя таймера, вызвавшего этот метод = " + name);
        }
    }
}