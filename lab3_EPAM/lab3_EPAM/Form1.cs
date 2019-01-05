using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab3_EPAM
{
    public partial class Form1 : Form
    {
        public static double Evaluate(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Solve1_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var pb in Controls.OfType<TextBox>())
            {
                if (pb.Text != "") { count++; }
            }
            label1.Text = Convert.ToString(count);
            switch (count)
            {
                case 1:
                    label1.Text = textBox1.Text;
                    break;
                case 2:
                    label1.Text = Convert.ToString(Nod.nodBigInput(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
                    break;
                case 3:
                    label1.Text = Convert.ToString(Nod.nodBigInput(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text)));
                    break;
                case 4:
                    label1.Text = Convert.ToString(Nod.nodBigInput(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text)));
                    break;
                case 5:
                    label1.Text = Convert.ToString(Nod.nodBigInput(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text)));
                    break;
            }
        }

        private void Solve2_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(Nod.binaryNod(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text)));
        }

        private void buildChart_Click(object sender, EventArgs e)
        {
            long elapsedMilliseconds_nod, elapsedMilliseconds_binaryNod;
            int a = 100202;
            int b = 300202;
            //string orient = "Bar";
            //string color = "Fire";
            Nod.nod(a, b, out elapsedMilliseconds_nod);
            Nod.binaryNod(a, b, out elapsedMilliseconds_binaryNod);
            goBuildChart(elapsedMilliseconds_nod, elapsedMilliseconds_binaryNod);
        }

        public void goBuildChart(long elapsedMilliseconds_nod, long elapsedMilliseconds_binaryNod)
        {
            chart1.Series["time"].Points.Clear();
            if (radioButton1.Checked) { chart1.Palette = ChartColorPalette.Fire; }
            else if (radioButton2.Checked) { chart1.Palette = ChartColorPalette.Berry; }
            else if (radioButton3.Checked) { chart1.Palette = ChartColorPalette.SeaGreen; }
            else { chart1.Palette = ChartColorPalette.SeaGreen; }

            if (radioButton5.Checked) { chart1.Series["time"].ChartType = SeriesChartType.Bar; }
            else if (radioButton6.Checked) { chart1.Series["time"].ChartType = SeriesChartType.Column; }
            else { chart1.Series["time"].ChartType = SeriesChartType.Column; }
            chart1.Series["time"].Points.AddXY("nod", elapsedMilliseconds_nod);
            chart1.Series["time"].Points.AddXY("binaryNod", elapsedMilliseconds_binaryNod);
        }
    }
    public class Nod
    {
        public static int nod(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b - a;
                }
            }
            return a;
        }
        public static int nodBigInput(params int[] values)
        {
            int result = values[0];
            for (int i = 1; i < values.Length; i++)
            {
                result = nod(result, values[i]);
            }
            return result;
        }
        public static int binaryNod(int a, int b)
        {
            if (a != 0 && b != 0)
            {
                if (a < 0)
                    a = -a;

                if (b < 0)
                    b = -b;

                int k = 1;

                while (a != 0 && b != 0)
                {
                    while (a % 2 == 0 && b % 2 == 0)
                    {
                        a /= 2;
                        b /= 2;
                        k *= 2;
                    }

                    if (a % 2 == 0 && b % 2 != 0)
                        while (a % 2 == 0)
                            a /= 2;

                    if (b % 2 == 0 && a % 2 != 0)
                        while (b % 2 == 0)
                            b /= 2;

                    if (a >= b)
                        a -= b;
                    else
                        b -= a;
                }

                return b * k;
            }
            else return 0;
            }
        public static int binaryNod(int a, int b, out long elapsedMilliseconds_binaryNod)
        {
            int result = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 1; i < 2000000; i++) {
                binaryNod(a, b);
            }
            stopWatch.Stop();
            elapsedMilliseconds_binaryNod = stopWatch.ElapsedMilliseconds;
            result = binaryNod(a, b);
            return result;
        }
        public static int nod(int a, int b, out long elapsedMilliseconds_nod)
        {
            int result = 0;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            for (int i = 1; i < 2000000; i++)
            {
                nod(a, b);
            }            
            stopWatch.Stop();
            elapsedMilliseconds_nod = stopWatch.ElapsedMilliseconds;
            result = nod(a, b);
            return result;
        }
    }
}