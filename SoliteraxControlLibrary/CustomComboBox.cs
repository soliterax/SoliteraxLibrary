using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Design;

namespace SoliteraxControlLibrary
{
    [DefaultEvent("OnSelectedIndexChanged")]
    public class CustomComboBox : UserControl
    {

        private Color BACKCOLOR = Color.White;
        private Color ICONCOLOR = Color.Green;
        private Color LISTBACKCOLOR = Color.Blue;
        private Color LISTTEXTCOLOR = Color.Black;
        private Color BORDERCOLOR = Color.Green;
        private Padding BORDERSIZE = new Padding(1,1,1,1);

        [Category("Soliterax Control Library - Item")]
        public Color BackColor
        {
            get
            {
                return BACKCOLOR;
            }
            set
            {
                this.BACKCOLOR = value;
                lblTxt.BackColor = value;
                btnIcon.BackColor = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public Color IconColor
        {
            get
            {
                return ICONCOLOR;
            }
            set
            {
                this.ICONCOLOR = value;
                btnIcon.Invalidate();
            }
        }

        [Category("Soliterax Control Library - Item")]
        public Color ListBackColor
        {
            get
            {
                return LISTBACKCOLOR;
            }
            set
            {
                this.LISTBACKCOLOR = value;
                cmbList.BackColor = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public Color ListTextColor
        {
            get
            {
                return LISTTEXTCOLOR;
            }
            set
            {
                this.LISTTEXTCOLOR = value;
                cmbList.ForeColor = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public Color BorderColor
        {
            get
            {
                return BORDERCOLOR;
            }
            set
            {
                this.BORDERCOLOR = value;
                base.BackColor = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public Padding BorderSize
        {
            get
            {
                return BORDERSIZE;
            }
            set
            {
                this.BORDERSIZE = value;
                this.Padding = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                lblTxt.ForeColor = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                lblTxt.Font = value;
                cmbList.Font = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public string Texts
        {
            get
            {
                return lblTxt.Text;
            }
            set
            {
                lblTxt.Text = value;
            }
        }

        [Category("Soliterax Control Library - Item")]
        public ComboBoxStyle DropDownStyle
        {
            get
            {
                return cmbList.DropDownStyle;
            }
            set
            {
                if(cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }

        //Data
        [Category("Soliterax Control Library - Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return cmbList.Items; }
        }
        [Category("Soliterax Control Library - Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(null)]
        public object DataSource
        {
            get { return cmbList.DataSource; }
            set { cmbList.DataSource = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Localizable(true)]
        public AutoCompleteStringCollection AutoCompleteCustomSource
        {
            get { return cmbList.AutoCompleteCustomSource; }
            set { cmbList.AutoCompleteCustomSource = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteSource.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteSource AutoCompleteSource
        {
            get { return cmbList.AutoCompleteSource; }
            set { cmbList.AutoCompleteSource = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [Browsable(true)]
        [DefaultValue(AutoCompleteMode.None)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public AutoCompleteMode AutoCompleteMode
        {
            get { return cmbList.AutoCompleteMode; }
            set { cmbList.AutoCompleteMode = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [Bindable(true)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedItem
        {
            get { return cmbList.SelectedItem; }
            set { cmbList.SelectedItem = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set { cmbList.SelectedIndex = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return cmbList.DisplayMember; }
            set { cmbList.DisplayMember = value; }
        }
        [Category("Soliterax Control Library - Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return cmbList.ValueMember; }
            set { cmbList.ValueMember = value; }
        }

        private ComboBox cmbList;
        private Label lblTxt;
        private Button btnIcon;

        public event EventHandler OnSelectedIndexChanged;

        public CustomComboBox()
        {
            cmbList = new ComboBox();
            lblTxt = new Label();
            btnIcon = new Button();

            cmbList.BackColor = BACKCOLOR;
            cmbList.Font = new Font(this.Font.Name, 10F);
            cmbList.ForeColor = LISTTEXTCOLOR;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndex_Changed);
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);

            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = BACKCOLOR;
            btnIcon.Size = new Size(30, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);

            lblTxt.Dock = DockStyle.Fill;
            lblTxt.AutoSize = false;
            lblTxt.BackColor = BACKCOLOR;
            lblTxt.TextAlign = ContentAlignment.MiddleLeft;
            lblTxt.Padding = new Padding(0, 0, 0, 0);
            lblTxt.Font = new Font(this.Font.Name, 10F);
            lblTxt.Click += new EventHandler(Surface_Click);
            lblTxt.MouseEnter += new EventHandler(Surface_MouseEnter);
            lblTxt.MouseLeave += new EventHandler(Surface_MouseLeave);

            this.Controls.Add(lblTxt);
            this.Controls.Add(btnIcon);
            this.Controls.Add(cmbList);

            this.MinimumSize = new Size(200, 30);
            this.Size = new Size(200, 30);
            this.ForeColor = Color.DimGray;
            this.Padding = BORDERSIZE;
            this.BackColor = BORDERCOLOR;
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        private void Surface_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void Surface_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblTxt.Width;
            cmbList.Location = new Point()
            {
                X = this.Width - this.Padding.Right - cmbList.Width,
                Y = lblTxt.Bottom - cmbList.Right
            };
        }

        private void Surface_Click(object sender, EventArgs e)
        {
            this.OnClick(e);

            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;
        }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {
            //Fields
            int iconWidth = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidth) / 2, (btnIcon.Height - iconHeight) / 2, iconWidth, iconHeight);
            Graphics graph = e.Graphics;

            using(GraphicsPath path = new GraphicsPath())
                using(Pen pen = new Pen(ICONCOLOR, 2))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                
                path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (iconWidth / 2), rectIcon.Bottom);
                path.AddLine(rectIcon.X + (iconWidth / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
                graph.DrawPath(pen, path);
            }
        }

        private void Icon_Click(object sender, EventArgs e)
        {
            cmbList.Select();
            cmbList.DroppedDown = true;
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            lblTxt.Text = cmbList.Text;
        }

        private void ComboBox_SelectedIndex_Changed(object sender, EventArgs e)
        {
            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);

            lblTxt.Text = cmbList.Text;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
