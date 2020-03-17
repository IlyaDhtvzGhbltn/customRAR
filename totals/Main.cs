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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            var curDir = Directory.GetCurrentDirectory();
            comboBox1.Items.Add(curDir);
            comboBox1.SelectedIndex = 0;
            this.ActiveControl = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = $"Извлечение {Base.root}";
            button1.Text = "Приостановить";
            borderDevide.Show();
            comboBox1.Hide();
            button3.Hide();

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            Font font = new Font("Arial", 8.0f);
            textBox1.Font = font;
            textBox1.Location = new Point(0,0);

            textBox1.Text = $"Извлечение файлов в папку {comboBox1.Text}\r\nИзвлечение из {Base.name}";
            this.ActiveControl = null;
            var passForm = new Password( comboBox1.Text );
            passForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    comboBox1.Items.RemoveAt(0);
                    comboBox1.Items.Add(fbd.SelectedPath);
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var forms = Application.OpenForms;

            var code = e.KeyCode;
            if (code == Keys.Escape)
                Application.Exit();
        }
    }
}
