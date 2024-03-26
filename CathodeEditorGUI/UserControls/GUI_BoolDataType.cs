﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATHODE.Scripting;
using CathodeLib;
using CATHODE;

namespace CommandsEditor.UserControls
{
    public partial class GUI_BoolDataType : ParameterUserControl
    {
        cBool boolVal = null;

        public GUI_BoolDataType()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        public void PopulateUI(cBool cBool, string paramID)
        {
            boolVal = cBool;
            checkBox1.Text = paramID;
            checkBox1.Checked = cBool.value;
            this.deleteToolStripMenuItem.Text = "Delete '" + paramID + "'";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            boolVal.value = checkBox1.Checked;
        }
    }
}
