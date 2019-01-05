using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4_EPAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Triangle first = new Triangle(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));
                label1.Text = Convert.ToString(first.area());
                label2.Text = Convert.ToString(first.perimeter());
            }
            catch (Exception)
            {
                label1.Text = "такого треугольника не существует";
                label2.Text = " ";
            }
        }
    }
}
