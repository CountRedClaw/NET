using System;

namespace lab10_EPAM
{
    public class MyEventArgs : EventArgs
    {
        public MyEventArgs(String arg) { Value = arg; }

        public String Value { get; private set; }
    }
}