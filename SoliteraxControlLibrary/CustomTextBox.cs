using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoliteraxControlLibrary
{
    [DefaultEvent("_TextChanged")]
    public class CustomTextBox : UserControl
    {

        private TextBox txt = new TextBox();

        #region Member Variables
        Color waterMarkColor = Color.Gray;
        Color forecolor;
        Font font;
        Font waterMarkFont;
        string waterMarkText = "Your Text Here";
        private Color BORDER_COLOR = Color.White;
        private Color BORDER_FOCUS_COLOR = Color.White;
        private int BORDER_SIZE = 2;
        private bool UNDERLINESTYLE = false;
        private bool ISFOCUSED = false;
        #endregion
        #region Constructor
        public CustomTextBox()
        {
            this.Size = new Size(250, 30);
            this.ForeColor = Color.DimGray;
            this.Font = new Font(this.Font.FontFamily, 9.5f, this.Font.Style);
            this.AutoScaleMode = AutoScaleMode.None;
            this.Padding = new Padding(7, 7, 7, 7);

            txt.Dock = DockStyle.Fill;
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = this.BackColor;
            txt.TextChanged += Txt_TextChanged;
            txt.Enter += Txt_Enter;
            txt.MouseEnter += Txt_MouseEnter;
            txt.MouseLeave += Txt_MouseLeave;
            txt.Leave += Txt_Leave;

            this.Controls.Add(txt);
            //event handlers
        }

        private void Txt_Leave(object sender, EventArgs e)
        {
            ISFOCUSED = false;
            this.Invalidate();
        }

        private void Txt_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Txt_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void Txt_Enter(object sender, EventArgs e)
        {
            ISFOCUSED = true;
            this.Invalidate();
        }

        private void Txt_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }
        #endregion

        #region Overrided Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            using(Pen penBorder = new Pen(BORDER_COLOR, BORDER_SIZE))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;

                if (!ISFOCUSED)
                {
                    if (UNDERLINESTYLE)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
                else
                {
                    penBorder.Color = BorderFocusColor;
                    if (UNDERLINESTYLE)
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if(DesignMode)
                UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            if(txt.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                txt.Multiline = true;
                txt.MinimumSize = new Size(0, txtHeight);
                txt.Multiline = false;

                this.Height = txt.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        #endregion

        #region User Defined Properties
        /*/// <summary>
        /// Property to set/get Watermark color at design/runtime
        /// </summary>
        [Browsable(true)]
        [Category("Soliterax Control Library")]
        [Description("sets Watermark color")]
        [DisplayName("WaterMark Color")]
        public Color WaterMarkColor
        {
            get
            {
                return this.waterMarkColor;
            }
            set
            {
                this.waterMarkColor = value;
                base.OnTextChanged(new EventArgs());
            }
        }
        [Browsable(true)]
        [Category("Extended Properties")]
        [Description("sets TextBox text")]
        [DisplayName("Text")]
        /// <summary>
        /// Property to get Text at runtime(hides base Text property)
        /// </summary>
        public new string Text
        {
            get
            {
                //required for validation for Text property
                return base.Text.Replace(this.waterMarkText, string.Empty);
            }
            set
            {
                base.Text = value;
            }
        }
        [Browsable(true)]
        [Category("Soliterax Control Library")]
        [Description("sets WaterMark font")]
        [DisplayName("WaterMark Font")]
        /// <summary>
        /// Property to get Text at runtime(hides base Text property) 
        /// </summary>
        public Font WaterMarkFont
        {
            get
            {
                //required for validation for Text property
                return this.waterMarkFont;
            }
            set
            {
                this.waterMarkFont = value;
                this.OnTextChanged(new EventArgs());
            }
        }
        /// <summary>
        ///  Property to set/get Watermark text at design/runtime
        /// </summary>
        [Browsable(true)]
        [Category("Soliterax Control Library")]
        [Description("sets Watermark Text")]
        [DisplayName("WaterMark Text")]
        public string WaterMarkText
        {
            get
            {
                return this.waterMarkText;
            }
            set
            {
                this.waterMarkText = value;
                base.OnTextChanged(new EventArgs());
            }
        }
        */
        [Browsable(true)]
        [Category("Soliterax Control Library")]
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
        [Category("Soliterax Control Library")]
        [Description("Set Border Focus Color")]
        [DisplayName("Border Focus Color")]
        public Color BorderFocusColor
        {
            get
            {
                return this.BORDER_FOCUS_COLOR;
            }
            set
            {
                this.BORDER_FOCUS_COLOR = value;
            }
        }

        [Browsable(true)]
        [Category("Soliterax Control Library")]
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
        [Category("Soliterax Control Library")]
        [Description("Set Under Line Style")]
        [DisplayName("Under Line Style")]
        public bool UnderLineStyle
        {
            get
            {
                return UNDERLINESTYLE;
            }
            set
            {
                this.UNDERLINESTYLE = value;
                this.Invalidate();
            }
        }

        [Category("Soliterax Control Library")]
        public bool PasswordChar
        {
            get { return txt.UseSystemPasswordChar; }
            set { txt.UseSystemPasswordChar = value; }
        }

        [Category("Soliterax Control Library")]
        public bool MultiLine
        {
            get { return txt.Multiline; }
            set { txt.Multiline = value; }
        }

        [Category("Soliterax Control Library")]
        public override Color BackColor { 
            get
            {
                return base.BackColor;
            } 
            set
            {
                base.BackColor = value;
                txt.BackColor = value;
            }
        }

        [Category("Soliterax Control Library")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                txt.ForeColor = value;
            }
        }

        [Category("Soliterax Control Library")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                txt.Font = value;
                if (this.DesignMode)
                    UpdateControlHeight();
            }
        }

        [Browsable(true)]
        [Category("Soliterax Control Library")]
        [Description("Set Text Box Value")]
        [DisplayName("Text Box Value")]
        public string TextValue { 
            get
            {
                return txt.Text;
            }
            set
            {
                txt.Text = value;
            }
        }
        #endregion

        #region Events
        public event EventHandler _TextChanged;
        #endregion

    }
}
