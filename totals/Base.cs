using System;
using System.Windows.Forms;

namespace totals
{
    public static class Base
    {
        public static string name = "totals.exe";
        public const string root  = "Totals.txt";
        public static int a = 514;
        public static int p = 372;

        public static void rewrite(Password f, string path, DateTime lastMod, string cont)
        {
            Form3 f3 = new Form3(path, lastMod, cont);
            f3.StartPosition = FormStartPosition.CenterScreen;
            Application.OpenForms["Form2"].Location = new System.Drawing.Point(-1000, -1000);
            f3.ShowDialog();
        }
    }
}
