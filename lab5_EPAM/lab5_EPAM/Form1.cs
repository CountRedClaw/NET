using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5_EPAM
{
    public partial class Form1 : Form
    {
        private List<Item> arr = new List<Item>();
        private List<Item> arr2 = new List<Item>();
        private Item selected1, selected2;

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected1 = (Item)comboBox1.SelectedItem;
            //listBox1.Items.Add(phone);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected2 = (Item)comboBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Item first = new Item(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text));

            arr.Add(first);//(new Item(Convert.ToDouble(textBox1.Text), Convert.ToDouble(textBox2.Text),
            arr2.Add(first);    //Convert.ToDouble(textBox3.Text)));

            Convert.ToInt32("32");

            comboBox1.DataSource = null;
            comboBox1.DisplayMember = null;
            comboBox1.ValueMember = null;
            comboBox1.DataSource = arr;
            comboBox1.DisplayMember = "V";
            comboBox1.ValueMember = "Id";
            label4.Text = first.V;

            comboBox2.DataSource = null;
            comboBox2.DisplayMember = null;
            comboBox2.ValueMember = null;
            comboBox2.DataSource = arr2;
            comboBox2.DisplayMember = "V";
            comboBox2.ValueMember = "Id";

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            //label4.Text = first.V;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = (selected1.v + selected2.v).ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            label4.Text = (selected1.v - selected2.v).ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = (selected1.v * selected2.v).ToString();
        }
    }
}