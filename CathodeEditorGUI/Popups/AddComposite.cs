﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATHODE;
using CATHODE.Scripting;
using CathodeLib;
using CommandsEditor.Popups.Base;

namespace CommandsEditor
{
    public partial class AddComposite : BaseWindow
    {
        public AddComposite() : base()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            for (int i = 0; i < Editor.commands.Entries.Count; i++)
            {
                if (Editor.commands.Entries[i].name == textBox1.Text)
                {
                    MessageBox.Show("Failed to create composite.\nA composite with this name already exists.", "Composite already exists.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            Editor.commands.AddComposite(textBox1.Text);
            this.Close();
        }
    }
}
