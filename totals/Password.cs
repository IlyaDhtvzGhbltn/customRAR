using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace totals
{
    public partial class Password : Form
    {
        private readonly string path;
        public Password()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }
        public Password(string path)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.path = path;
            this.ActiveControl = textBox1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void validate()
        {
            string pas = textBox1.Text;
            if (checkPass(pas))
            {
                string cont = Crypt.Decrypting(pas);
                string outFile = Path.Combine(this.path, Base.root);
                DateTime lastModTime = File.GetLastWriteTime(outFile);
                bool exist = File.Exists(outFile);
                if (!exist)
                {
                    File.WriteAllText(outFile, cont);
                    Application.Exit();
                }
                if (exist)
                {
                    Base.rewrite(this, this.path, lastModTime, cont);
                    this.Close();
                }
            }
            else
            {
                this.Hide();
                var res = MessageBox.Show("Указан неверный пароль", "Ошибка", MessageBoxButtons.OK);
                if (res == DialogResult.OK)
                {
                    this.Show();
                }
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            var code = e.KeyCode;
            if (code == Keys.Escape)
                Application.Exit();
            if (code == Keys.Enter)
                validate();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            var reas = e.CloseReason;
            var flag = e.Cancel;
            //if(reas == CloseReason.ApplicationExitCall)
            //    Application.Exit();
        }
    }
}
