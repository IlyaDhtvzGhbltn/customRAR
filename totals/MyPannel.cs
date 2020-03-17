using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace totals
{
    class MyPanel : Panel
    {
        private Color colorBorder = Color.DarkGreen;

        public MyPanel()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(
                new Pen(
                    new SolidBrush(colorBorder), 1),
                    e.ClipRectangle);
        }

        public Color BorderColor
        {
            get
            {
                return colorBorder;
            }
            set
            {
                colorBorder = value;
            }
        }
    }
}