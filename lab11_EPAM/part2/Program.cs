using System;
using part2.concrete;

namespace part2
{
    class Program
    {
        public static void Main()
        {
            IFactory factory1 = new CanteenFurnitureFactory();
            Client client1 = new Client(factory1);
            client1.Run();

            IFactory factory2 = new OfficeFurnitureFactory();
            Client client2 = new Client(factory2);
            client2.Run();

            Console.ReadKey();
        }
    }
}
