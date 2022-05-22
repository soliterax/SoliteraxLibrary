using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SoliteraxControlLibrary
{
    public class CustomPanel : Panel
    {

        //Fields
        private bool BORDER = false;
        private bool HAVEELLIPSE = false;
        private int BORDER_LEFT_SIZE = 1;
        private int BORDER_RIGHT_SIZE = 1;
        private int BORDER_TOP_SIZE = 1;
        private int BORDER_BOTTOM_SIZE = 1;
        private Color BORDER_LEFT_COLOR = Color.White;
        private Color BORDER_RIGHT_COLOR = Color.White;
        private Color BORDER_TOP_COLOR = Color.White;
        private Color BORDER_BOTTOM_COLOR = Color.White;
        private int BORDER_RADIUS = 30;

        //Constructor
        public CustomPanel()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BORDER)
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                    BORDER_LEFT_COLOR, BORDER_LEFT_SIZE, ButtonBorderStyle.Solid,
                    BORDER_TOP_COLOR, BORDER_TOP_SIZE, ButtonBorderStyle.Solid,
                    BORDER_RIGHT_COLOR, BORDER_RIGHT_SIZE, ButtonBorderStyle.Solid,
                    BORDER_BOTTOM_COLOR, BORDER_BOTTOM_SIZE, ButtonBorderStyle.Solid);
            if (HAVEELLIPSE)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
                RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

                if(BORDER_RADIUS > 2)
                {
                    using (GraphicsPath pathGurface = GetFigurePath(rectSurface, BORDER_RADIUS))
                        using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BORDER_RADIUS - 1F))
                            using (Pen penSurface = new Pen(this.Parent.BackColor, 2)) 
                                using (Pen penBorder = new Pen(borderColor, borderSize))
                                {
                                    penBorder.Alignment = PenAlignment.Inset;
                                    this.Region = new Region(pathGurface);

                                    e.Graphics.DrawPath(penSurface, pathGurface);

                                    if (BORDER_RIGHT_SIZE >= 1)
                                        e.Graphics.DrawPath(penBorder, pathBorder);
                                }
                }
                else
                {
                    this.Region = new Region(rectSurface);
                    if(BORDER_RIGHT_SIZE >= 1)
                    {
                        using(Pen penBorder = new Pen(borderColor, borderSize))
                        {
                            penBorder.Alignment = PenAlignment.Inset;
                            e.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                        }
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

        public bool haveBorder
        {
            get
            {
                return this.BORDER;
            }
            set
            {
                this.BORDER = value;
            }
        }

        public bool haveEllipse
        {
            get
            {
                return this.HAVEELLIPSE;
            }
            set
            {
                this.HAVEELLIPSE = value;
            }
        }

        public int borderSize
        {
            get
            {
                return this.BORDER_RIGHT_SIZE;
            }
            set
            {
                this.BORDER_RIGHT_SIZE = value;
                this.BORDER_LEFT_SIZE = value;
                this.BORDER_TOP_SIZE = value;
                this.BORDER_BOTTOM_SIZE = value;
            }
        }

        public int borderRightSize
        {
            get
            {
                return this.BORDER_RIGHT_SIZE;
            }
            set
            {
                this.BORDER_RIGHT_SIZE = value;
            }
        }

        public int borderLeftSize
        {
            get
            {
                return this.BORDER_LEFT_SIZE;
            }
            set
            {
                this.BORDER_LEFT_SIZE = value;
            }
        }

        public int borderTopSize
        {
            get
            {
                return this.BORDER_TOP_SIZE;
            }
            set
            {
                this.BORDER_TOP_SIZE = value;
            }
        }

        public int borderBottomSize
        {
            get
            {
                return this.BORDER_BOTTOM_SIZE;
            }
            set
            {
                this.BORDER_BOTTOM_SIZE = value;
            }
        }

        public Color borderColor
        {
            get
            {
                return this.BORDER_RIGHT_COLOR;
            }
            set
            {
                this.BORDER_RIGHT_COLOR = value;
                this.BORDER_LEFT_COLOR = value;
                this.BORDER_TOP_COLOR = value;
                this.BORDER_BOTTOM_COLOR = value;
            }
        }

        public Color borderRightColor
        {
            get
            {
                return this.BORDER_RIGHT_COLOR;
            }
            set
            {
                this.BORDER_RIGHT_COLOR = value;
            }
        }

        public Color borderLeftColor
        {
            get
            {
                return this.BORDER_LEFT_COLOR;
            }
            set
            {
                this.BORDER_LEFT_COLOR = value;
            }
        }

        public Color borderTopColor
        {
            get
            {
                return this.BORDER_TOP_COLOR;
            }
            set
            {
                this.BORDER_TOP_COLOR = value;
            }
        }

        public Color borderBottomColor
        {
            get
            {
                return this.BORDER_BOTTOM_COLOR;
            }
            set
            {
                this.BORDER_BOTTOM_COLOR = value;
            }
        }

        public int borderRadius
        {
            get
            {
                return this.BORDER_RADIUS;
            }
            set
            {
                this.BORDER_RADIUS = value;
            }
        }
    }
}
