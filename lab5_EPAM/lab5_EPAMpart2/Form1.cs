using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_EPAMpart2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Polynomial pol1 = new Polynomial(textBox1.Text);
            Polynomial pol2 = new Polynomial(textBox2.Text);
            Polynomial pol3 = new Polynomial();
            pol3 = pol1 + pol2;
            label1.Text = pol3.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Polynomial expected = new Polynomial("4x-6y");
            Polynomial first = new Polynomial("3x-4y");
            Polynomial second = new Polynomial("-x+2y");
            Polynomial actual = new Polynomial();
            actual = first - second;


            Polynomial pol1 = new Polynomial(textBox1.Text);
            
            Polynomial pol2 = new Polynomial(textBox2.Text);
            Polynomial pol3 = new Polynomial();
            pol3 = pol1 - pol2;
            label2.Text = pol3.ToString();
        }
    }
}
