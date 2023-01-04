﻿using CATHODE.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CathodeEditorGUI
{
    public partial class CathodeEditorGUI_EditRootComposite : Form
    {
        List<Composite> composites = null;

        public CathodeEditorGUI_EditRootComposite()
        {
            InitializeComponent();
            rootComposite.BeginUpdate();
            rootComposite.Items.Clear();
            rootComposite.SelectedIndex = -1;
            composites = Editor.commands.Composites.OrderBy(o => o.name).ToList();
            for (int i = 0; i < composites.Count; i++)
            {
                rootComposite.Items.Add(composites[i].name);
                if (rootComposite.SelectedIndex == -1 && 
                    composites[i].shortGUID == Editor.commands.EntryPoints[0].shortGUID)
                {
                    rootComposite.SelectedIndex = i;
                }
            }
            rootComposite.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rootComposite.SelectedIndex == -1) return;
            Editor.commands.SetRootComposite(composites[rootComposite.SelectedIndex].shortGUID);
            this.Close();
        }
    }
}
