using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoliteraxControlLibrary
{
    [ToolboxBitmap(typeof(CustomButton), "CustomButton.bmp")]
    public class CustomButton : Button
    {

        int BORDER_RADIUS = 0;
        int BORDER_SIZE = 1;
        Color BORDER_COLOR = Color.White;

        public CustomButton()
        {
            base.FlatStyle = FlatStyle.Flat;
            base.BackColor = Color.White;
            base.ForeColor = Color.Black;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (BORDER_RADIUS > 2)
            {
                using (GraphicsPath pathGurface = GetFigurePath(rectSurface, BORDER_RADIUS))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BORDER_RADIUS - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(BORDER_COLOR, BORDER_SIZE))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathGurface);

                    e.Graphics.DrawPath(penSurface, pathGurface);

                    if (BORDER_SIZE >= 1)
                        e.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if (BORDER_SIZE >= 1)
                {
                    using (Pen penBorder = new Pen(BORDER_COLOR, BORDER_SIZE))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }

        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        public GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;

        }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Set Border Color")]
        [DisplayName("Border Color")]
        public Color BorderColor
        {
            get
            {
                return BORDER_COLOR;
            }
            set
            {
                this.BORDER_COLOR = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("Set Border Size")]
        [DisplayName("Border Size")]
        public int BorderSize
        {
            get
            {
                return BORDER_SIZE;
            }
            set
            {
                this.BORDER_SIZE = value;
                this.Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("MAke Border Ellipse")]
        [DisplayName("Border Radius")]
        public int BorderRadius
        {
            get
            {
                return BORDER_RADIUS;
            }
            set
            {
                this.BORDER_RADIUS = value;
                this.Invalidate();
            }
        }
    }
}
