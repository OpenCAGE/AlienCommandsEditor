﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CATHODE.Commands;
using CathodeLib;
using CATHODE;

namespace CathodeEditorGUI.UserControls
{
    public partial class GUI_EnumDataType : UserControl
    {
        cEnum enumVal = null;
        EnumDescriptor enumDesc = null;

        public GUI_EnumDataType()
        {
            InitializeComponent();

            comboBox1.BeginUpdate();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(Enum.GetNames(typeof(EnumType)));
            comboBox1.EndUpdate();
        }

        public void PopulateUI(cEnum cEnum, ShortGuid paramID)
        {
            enumVal = cEnum;
            enumDesc = EntityDB.GetEnum(cEnum.enumID);

            label13.Text = ShortGuidUtils.FindString(paramID);
            comboBox1.Text = enumDesc.Name;
            textBox1.Text = cEnum.enumIndex.ToString();

            try
            {
                toolTip1.SetToolTip(textBox1, enumDesc.Entries[cEnum.enumIndex]);
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            enumVal.enumID = ShortGuidUtils.Generate(comboBox1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = EditorUtils.ForceStringNumeric(textBox1.Text);
            enumVal.enumIndex = Convert.ToInt32(textBox1.Text);
        }
    }
}
