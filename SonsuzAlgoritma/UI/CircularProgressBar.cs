using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliteraxLibrary.UI
{
    public class CircularProgressBar : System.Windows.Forms.Control
    {
        public int Progress_Value
        {
            get { return Progress_Value; }
            set { Progress_Value = value; }
        }
        public int Progress_MaxValue
        {
            get { return Progress_MaxValue; }
            set { Progress_MaxValue = value; }
        }
        public System.Drawing.Color Progress_TextColor
        {
            get { return Progress_TextColor; }
            set { Progress_TextColor = value; }
        }
        public int Progress_TextSize
        {
            get { return Progress_TextSize; }
            set { Progress_TextSize = value; }
        }
        public System.Drawing.Color Progress_Color
        {
            get { return Progress_Color; }
            set { Progress_Color = value; }
        }

        public CircularProgressBar()
        {
            this.Progress_Value = 0;
            this.Progress_MaxValue = 100;
            this.Progress_TextColor = System.Drawing.Color.Blue;
            this.Progress_TextSize = 30;
            this.Progress_Color = System.Drawing.Color.Blue;
            this.Paint += CircularProgressBar_Paint;
        }

        private void CircularProgressBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(-90);
            System.Drawing.Pen obj_pen = new System.Drawing.Pen(Progress_Color);
            System.Drawing.Rectangle rect1 = new System.Drawing.Rectangle(0 - this.Width / 2 + 20, 0 - this.Height / 2 + 20, this.Width - 40, this.Height - 40);
            e.Graphics.DrawPie(obj_pen, rect1, 0, (int)(Progress_Value * 3.6));
            e.Graphics.FillPie(new System.Drawing.SolidBrush(Progress_Color), rect1, 0, (int)(Progress_Value * 3.6));

            obj_pen = new System.Drawing.Pen(this.BackColor);
            rect1 = new System.Drawing.Rectangle(0 - this.Width / 2 + 30, 0 - this.Height / 2 + 30, this.Width - 60, this.Height - 60);
            e.Graphics.DrawPie(obj_pen, rect1, 0, 360);
            e.Graphics.FillPie(new System.Drawing.SolidBrush(this.BackColor), rect1, 0, 360);

            e.Graphics.RotateTransform(90);
            System.Drawing.StringFormat f = new System.Drawing.StringFormat();
            f.LineAlignment = System.Drawing.StringAlignment.Center;
            f.Alignment = System.Drawing.StringAlignment.Center;
            e.Graphics.DrawString(Progress_Value + "%", new System.Drawing.Font("Arial", Progress_TextSize), new System.Drawing.SolidBrush(Progress_TextColor), rect1, f);

        }

        
    }
}
