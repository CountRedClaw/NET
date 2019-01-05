using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_EPAM
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class Vector
    {
        public double x, y, z;

        public Vector(double _x, double _y, double _z)
        {
                x = _x;
                y = _y;
                z = _z;
        }

        public static Vector operator +(Vector obj1, Vector obj2)
        {
            Vector v = new Vector(0, 0, 0);
            v.x = obj1.x + obj2.x;
            v.y = obj1.y + obj2.y;
            v.z = obj1.z + obj2.z;
            return v;
        }
        public static Vector operator -(Vector obj1, Vector obj2)
        {
            Vector v = new Vector(0, 0, 0);
            v.x = obj1.x - obj2.x;
            v.y = obj1.y - obj2.y;
            v.z = obj1.z - obj2.z;
            return v;
        }
        public static double operator *(Vector obj1, Vector obj2)
        {
            double result = obj1.x * obj2.x + obj1.y * obj2.y + obj1.z * obj2.z;
            return result;
        }
        public override string ToString()
        {
            return "(" + x + " ," + y + " ," + z + ")";
        }
    }

    public class Item
    {
        public static int i = 0;
        public int id;
        public Vector v;

        //public string myname;
        //public string myRptValue;

        /*public override string ToString()
        {
            return "(" + x + " ," + y + " ," + z + ")";
        }*/

        public Item(double _x, double _y, double _z)
        {
            v = new Vector(_x, _y, _z);
            id = i++;
        }

        public string V
        {
            get { return v.ToString(); }
        }

        public string Id { get; set; }
    }
}