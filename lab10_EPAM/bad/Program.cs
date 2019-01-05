using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bad
{
    class Program
    {
        static void Main(string[] args)
        {
            var boozer = new Boozer();
            boozer.OilEnded += OnOilEnded;

            var gp = new Gp();
            gp.OilEnded += OnOilEnded;

            gp.LetsGoShelkat();
            boozer.LetsGoDrink();
            Console.ReadKey();
        }

        private static void OnOilEnded(object Sender, EventArgs eventArgs)
        {
            if (Sender is Gp)
            {
                Console.WriteLine(Sender + " " +"Семки есть?");
            }
            else if (Sender is Boozer)
            {
                Console.WriteLine(Sender + " " + "Пора в магаз");
            }
        }
    }
}
