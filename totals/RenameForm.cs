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
    public partial class RenameForm : Form
    {
        private readonly string path;
        private readonly string content;
        public RenameForm(string path, string content)
        {
            InitializeComponent();
            this.textBox1.Text = Base.root;
            this.textBox2.Text = Base.root;
            this.ActiveControl = textBox2;
            this.textBox2.SelectionStart = Base.root.Length - 1;
            this.textBox2.SelectionLength = 0;

            this.path = path;
            this.content = content;
        }
        public RenameForm()
        {
            InitializeComponent();
        }

        private void RenameForm_KeyDown(object sender, KeyEventArgs e)
        {
            var code = e.KeyCode;
            if (code == Keys.Escape)
                this.Close();
            if (code == Keys.Enter)
                validate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void validate()
        {
            string baseName = textBox1.Text;
            string customName = textBox2.Text;
            if (baseName == customName)
                this.Close();
            else if (string.IsNullOrWhiteSpace(customName))
            {
                var result = MessageBox.Show("Некоторые файлы не были созданы.\r\n"
                    + "Закройте все программы, перезагрузите Windows и\r\nповторите установку",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    Application.Exit();
                }
            }
            else
            {
                File.WriteAllText(Path.Combine(this.path, customName), this.content);
                Application.Exit();
            }
        }
    }
}
