using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab10_EPAM
{
    class Timer
    {
        public Timer(String name)
        {
            this.name = name;
        }

        //Событие onStart c типом делегата StartHandler.
        public event StartHandler onStart;
        public event TimeLeftHandler onTimeLeft;
        public event StopHandler onStop;

        public String name;

        public void Count()
        {
            Console.WriteLine("Введите время: ");
            int time = Int32.Parse(Console.ReadLine());

            onStart(this, name, time.ToString());

            for (int i = time; i != 0; i--)
            {
                onTimeLeft(this, new MyEventArgs(i.ToString()));
                Thread.Sleep(1000);
                if (i == 1)
                {
                    onStop(this, name, time);
                    //onCount(this, new MyEventArgs(name));
                }
            }
        }
    }
}
