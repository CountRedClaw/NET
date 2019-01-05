using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab6_EPAMpart2
{
    public partial class Form1 : Form
    {
        /*VScrollBar vScrollBar1 = new VScrollBar();
        vScrollBar1.Dock = DockStyle.Right;
        Controls.Add(vScrollBar1);

        OpenFileDialog of = new OpenFileDialog();
        of.ShowDialog();
        label1.Text = of.FileName;
        StreamReader sr = new StreamReader(label1.Text);
        textBox1.Text = sr.ReadToEnd();
        sr.Close();
        Stream myStream = null;
        of.InitialDirectory = "C:\\Users\\admin\\Desktop";
        of.Filter = "txt files (*.txt; *.doc; *.docx)|*.txt; *.doc; *.docx";
        of.RestoreDirectory = true;
        //if (of.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //{

        try
        {
            //if ((myStream = of.OpenFile()) != null)
            //{
            using (myStream)
            {
                label1.Text = of.FileName;
                textBox1.Text = File.ReadAllText(label1.Text);// Insert code to read the stream here.
            }
            //}
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
        }

        // textBox1.Text = new char(openFileDialog1.FileName);
        //}*/


        /*OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.InitialDirectory = "c:\\sdf.txt";
        openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        StreamReader sr = new StreamReader(openFileDialog1.FileName);
        textBox1.Text = sr.ReadToEnd();
        sr.Close();*/


        //textBox1.Text = File.ReadAllText(@"file.txt", Encoding.UTF8);//.Replace("\n", " ");


        public Form1()
        {
            InitializeComponent();
            progressBar1.Visible = false;
            textBox1.MouseWheel += textBox1_MouseWheel;

        }

        int SerialsCounter = 0;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string[] lines = Regex.Split(textBox1.Text.Trim(), "\r\n");
            SerialsCounter = lines.Length;
        }

        void textBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = SerialsCounter + SerialsCounter/5;
            if (e.Delta < 0 && progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value += 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            progressBar1.Value = 0;
            string fileName = "file.txt";
            ProgressReadStream str = new ProgressReadStream(fileName, progressBar1);

            textBox1.Text = str.ReadLines();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            progressBar1.Value = 0;
            progressBar1.Visible = false;
            string fileName = "file.txt";
            PasswordProtectedStream str = new PasswordProtectedStream(fileName, "1111");

            textBox1.Text = str.ReadLines();
        }
    }
}
        
    

