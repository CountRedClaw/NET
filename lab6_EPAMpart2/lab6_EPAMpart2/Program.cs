using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace lab6_EPAMpart2
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    abstract class StreamDecorator : Stream
    {
        protected string path;

        public StreamDecorator(string path)
        {
            this.path = path;
        }
    }

    class PasswordProtectedStream : StreamDecorator
    {
        string pass;
        public PasswordProtectedStream(string path, string pass) : base(path)
        {
            this.pass = pass;
            this.path = path;
        }

        public string ReadLines()
        {
            /*InputBox.InputBox inputBox = new InputBox.InputBox();
            MessageBox.Show(inputBox.getString());*/

            StreamReader text;
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите пароль:");
            StringBuilder stringBuilder = new StringBuilder();

            if (result.Equals(pass))
            {
                text = new StreamReader(path, Encoding.GetEncoding(1251));
                string sLine = "";

                while (sLine != null)
                {
                    sLine = text.ReadLine();
                    if (sLine != null)
                        stringBuilder.Append(sLine + "\r\n");
                }
                text.Close();

                return stringBuilder.ToString();
            }
            else
            {
                MessageBox.Show("Пароль введён неправильно");
                return stringBuilder.ToString();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();

        }

        public override bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanSeek
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }

    class ProgressReadStream : StreamDecorator
    {
        public ProgressReadStream(string path, ProgressBar progressBar) : base(path)
        {
            progressBar.Visible = true;
            this.path = path;
        }

        public string ReadLines()
        {   
            StreamReader text;
            StringBuilder stringBuilder = new StringBuilder();

            text = new StreamReader(path, Encoding.GetEncoding(1251));
            string sLine = "";

            while (sLine != null)
            {
                sLine = text.ReadLine();
                if (sLine != null)
                    stringBuilder.Append(sLine + "\r\n");
            }
            text.Close();

            return stringBuilder.ToString();
        }
        
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();

        }

        public override bool CanRead
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanSeek
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool CanWrite
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}
