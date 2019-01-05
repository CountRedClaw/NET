using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace lab5_EPAMpart2
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

    public class Polynomial
    {
        private Dictionary<String, int> dic = new Dictionary<String, int>();
        private String temp = "";
        ArrayList list = new ArrayList();


        public String res1;

        public Polynomial()
        {

        }

        public Polynomial(String input)
        {
            foreach (var ch in input)               // разбиение входной строки на символы
            {
                list.Add(ch);
            }
            for (int i = 0; i < list.Count; i++)        // вставление "+" для дальнейшего разделения на одночлены
            {
                if (list[i].ToString() == "-")
                {
                    list.Insert(i, "+");
                    i++;
                }
            }
            if ((list[0] != "+") && (list[0] != "-")) { list.Insert(0, "+"); }  // проверка на наличие плюса в начале и вставка если его нет

            foreach (var s in list)     // объединение в строку +-3x+-2y+z
            {
                temp += s;
            }
            
            string[] split;             // разделение на одночлены
            if (temp.Length > 1)
            {
                split = temp.Split('+');
            }
            else
            {
                split = new string[1];
                split[0] = temp;
            }

            list.Clear();
            list.AddRange(split);
            if (list.Count > 1) { list.RemoveAt(0); }

            foreach (String s in list)                  // Запись в словарь
            {
                String letter = s.Substring(s.Length - 1);

                int number = Convert.ToInt32((s.Length == 1) ? "1" : ((s.Substring(0, s.Length - 1) == "-" ? "-1" : s.Substring(0, s.Length - 1))));
                dic.Add(letter, number);
            }
        }

        public static Polynomial operator +(Polynomial obj1, Polynomial obj2)
        {
            Polynomial p = new Polynomial();
            var choise = (obj1.dic.Count < obj2.dic.Count) ? obj1 : obj2;
            var el = (obj1.dic.Count > obj2.dic.Count) ? obj1 : obj2;
            ICollection<String> keys = choise.dic.Keys;

            foreach (var k in keys.ToArray())
            {
                if (el.dic.ContainsKey(k))
                {
                    p.dic.Add(k, obj1.dic[k] + obj2.dic[k]);
                    el.dic.Remove(k);
                }
            }
            p.dic = p.dic.Concat(el.dic).ToDictionary(x => x.Key, x => x.Value);
            return p;
        }

        public static Polynomial operator -(Polynomial obj1, Polynomial obj2)
        {
            Polynomial p = new Polynomial();
            var choise = (obj1.dic.Count < obj2.dic.Count) ? obj1 : obj2;
            var el = (obj1.dic.Count > obj2.dic.Count) ? obj1 : obj2;
            ICollection<String> keys = choise.dic.Keys;

            foreach (var k in keys.ToArray())
            {
                if (el.dic.ContainsKey(k))
                {
                    p.dic.Add(k, obj1.dic[k] - obj2.dic[k]);
                    el.dic.Remove(k);
                }
            }
            p.dic = p.dic.Concat(el.dic).ToDictionary(x => x.Key, x => x.Value);
            return p;
        }

        public override String ToString()
        {
            String temp = "";
            ICollection<String> keys = dic.Keys;
            String isOne(int i)                 // добавление "+" туда, где это необходимо
            {
                if (i == 1)
                {
                    return "+";
                }
                if (i >= 0)
                {
                    return "+" + Convert.ToString(i);
                }
                return Convert.ToString(i);
            }

            foreach (String k in keys)          // запись многочлена в строку
            {
                if (dic[k] != 0)
                    temp += isOne(dic[k]) + k;
            }
            if (temp.Length == 0) { temp = "0"; }
            if (temp[0] == '+') { temp = temp.Remove(0, 1); }
            return temp;
        }
    }
}