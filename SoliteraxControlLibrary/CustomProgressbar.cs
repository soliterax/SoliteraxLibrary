using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using SoliteraxControlLibrary;
using System.ComponentModel;

namespace SoliteraxControlLibrary
{
    public class CustomProgressbar : CustomPanel
    {

        private bool isAnimated = false;
        private int animateSpeed = 0;
        private int intvalue = 0;

        private Panel rawPanel = new Panel();
        private Panel progPanel = new Panel();
        private bool progressText = false;

        private Timer timer = new Timer();
        private Panel rightPanel = new Panel();
        private Panel leftPanel = new Panel();

        private CustomLabel progvalue = new CustomLabel();

        private Color progressIdleColor = Color.Blue;
        private Color progressRunColor = Color.Yellow;
        private Color progressStopColor = Color.Red;
        private Color progressFinishColor = Color.Green;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }

        public CustomProgressbar()
        {
            
            setupComponents();
            
        }

        void setupComponents()
        {
            this.Resize += CustomProgressbar_Resize;

            rawPanel.Location = new Point(0, 0);
            rawPanel.Size = base.Size;
            rawPanel.Name = "RawPanel";
            rawPanel.BackColor = base.BackColor;

            progPanel.BackColor = progressIdleColor;
            progPanel.Size = new Size(20, rawPanel.Size.Height);
            progPanel.Location = new Point(0, 0);
            progPanel.BackColor = progressIdleColor;
            progPanel.Name = "ProgPanel";

            timer.Interval = 100;
            timer.Tick += Progress_Tick;
            if (isAnimated == true)
                timer.Start();

            rightPanel.Location = new Point((rawPanel.Size.Width / 2), rawPanel.Location.Y);
            leftPanel.Location = new Point(rawPanel.Size.Width / 2, rawPanel.Location.Y);

            if (isAnimated)
            {
                this.Controls.Add(leftPanel);
                this.Controls.Add(rightPanel);
            }
            else
            {
                rawPanel.Controls.Add(progPanel);
                this.Controls.Add(rawPanel);
                if(progressText)
                    this.Controls.Add(progvalue);
            }

        }

        private void CustomProgressbar_Resize(object sender, EventArgs e)
        {
            rawPanel.Size = new Size(rawPanel.Size.Width + (this.Size.Width - rawPanel.Size.Width), rawPanel.Size.Height + (this.Size.Height - rawPanel.Size.Height));
            CalculateProgress(intvalue);
        }

        protected override void OnValidated(EventArgs e)
        {

            setupComponents();

        }

        

        private void Progress_Tick(object sender, EventArgs e)
        {
            if (!isAnimated)
                timer.Stop();

            if(rightPanel.Location.X >= (rawPanel.Location.X + rawPanel.Size.Width))
            {
                rightPanel.Location = new Point((rawPanel.Size.Width /2), rawPanel.Location.Y);
                leftPanel.Location = new Point(rawPanel.Size.Width / 2, rawPanel.Location.Y);
            }

            rightPanel.Size = new Size(((intvalue / 2) * rawPanel.Size.Width) / 100, 0);
            rightPanel.Location = new Point(rightPanel.Location.X + (animateSpeed*10), rightPanel.Location.Y);
            leftPanel.Size = new Size(((intvalue / 2) * rawPanel.Size.Width) / 100, 0);
            leftPanel.Location = new Point(leftPanel.Location.X - (animateSpeed * 10), leftPanel.Location.Y);

            rightPanel.Location = new Point();
        }

        void CalculateProgress(int value)
        {

        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Animation set")]
        [DisplayName("ProgressBar Animation")]
        public bool IsAnimated
        {
            get
            {
                return isAnimated;
            }
            set
            {
                isAnimated = value;
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Animation Speed Set")]
        [DisplayName("ProgressBar Animation Speed")]
        public int AnimateSpeed
        {
            get
            {
                return animateSpeed;
            }
            set
            {
                animateSpeed = value;
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Progress Text Show")]
        [DisplayName("ProgressBar Show Text")]
        public bool IsShowText
        {
            get
            {
                return progressText;
            }
            set
            {
                progressText = value;
            }

        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Progress Value Set")]
        [DisplayName("ProgressBar Value")]
        public int ProgressValue
        {
            get { return intvalue; }
            set
            {
                progvalue.Text = value.ToString();
                intvalue = value;
                CalculateProgress(value);
                Invalidate();
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Progress Bar Color Set")]
        [DisplayName("Start Color")]
        public Color ProgressStartColor
        {
            get
            {
                return progressRunColor;
            }
            set
            {
                progressRunColor = value;
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Progress Bar Color Set")]
        [DisplayName("Stop Color")]
        public Color ProgressStopColor
        {
            get
            {
                return progressStopColor;
            }
            set
            {
                progressStopColor = value;
            }
        }

        [Browsable(true)]
        [Category("Progress Bar Properties")]
        [Description("Progress Bar Color Set")]
        [DisplayName("Finish Color")]
        public Color ProgressFinishColor
        {
            get
            {
                return progressFinishColor;
            }
            set
            {
                progressFinishColor = value;
            }
        }



    }
}
