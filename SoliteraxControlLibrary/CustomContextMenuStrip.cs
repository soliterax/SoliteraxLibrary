using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SoliteraxControlLibrary
{
    public class CustomContextMenuStrip : ContextMenuStrip
    {

        public CustomContextMenuStrip()
        {

        }

        protected override bool ProcessDialogKey(Keys ketData)
        {
            return true;
        }

    }
}
