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
    public class ComponentHover : Component
    {

        private Control referControl;
        private Control targetControl;

        public Control ReferencedControl
        {
            get { return referControl; }
            set
            {
                value.MouseDown += sys_MouseDown;
                value.MouseMove += sys_MouseMove;
                referControl = value;
            }
        }

        public Control TargetControl
        {
            get { return targetControl; }
            set => targetControl = value;
        }

        private Point mouseDownPos;

        private void sys_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                mouseDownPos = e.Location;
        }
        private void sys_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                targetControl.Left += e.X - mouseDownPos.X;
                targetControl.Top += e.Y - mouseDownPos.Y;
            }
        }
    }
}
