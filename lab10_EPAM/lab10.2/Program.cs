using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10._2
{
    public class MyEventArgs
    {
        public MyEventArgs(int arg) { Counter = arg; }

        public int Counter { get; private set; }
    }

    class Foo
    {
        private int _counter;

        public int Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                // сначала изменение _counter - это важно. 
                // даже в случае, если в обработчике события возникнет исключение,    
                // _counter все равно будет изменен    
                _counter = value;

                if (value == 5)
                    if (OnFifteen != null)
                        OnFifteen(this, new MyEventArgs(value));

            }
        }

        public delegate void MyEventHandler(object sender, MyEventArgs e);

        public event MyEventHandler OnFifteen;
    }

    class Program
    {
        static void Main()
        {
            var foo = new Foo { Counter = 1 };
            foo.OnFifteen += (object o, MyEventArgs arg) =>
                Console.WriteLine("Event fired! Value is {0}, {1}", arg.Counter, );

            for (var i = 1; i <= 10; i++)
                Console.WriteLine("foo.Counter = {0}", ++foo.Counter);

            Console.ReadLine();
        }
    }
}
