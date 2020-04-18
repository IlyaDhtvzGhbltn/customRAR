using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace totals
{
    public partial class Form3 : Form
    {
        private readonly string path;
        private readonly string content;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(string path, DateTime lastMod, string content)
        {
            Application.OpenForms["Form2"].Close();
            this.path = path;
            this.content = content;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.ActiveControl = buttYes;

            this.label2.Text = $"{Base.name}";
            this.label7.Text = "изменён" + lastMod.ToString("dd.MM.yyyy HH:mm");
            this.label8.Text = "изменён" + lastMod.ToString("dd.MM.yyyy HH:mm");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void buttNo_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void exit()
        {
            Application.Exit();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttYes_Click(object sender, EventArgs e)
        {
            replace();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            replace();
        }

        private void replace()
        {
            File.WriteAllText(Path.Combine(this.path, Base.root), this.content);
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var rf = new RenameForm(this.path, this.content);
            rf.ShowDialog();
        }
    }
}
