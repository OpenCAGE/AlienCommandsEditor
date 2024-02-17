﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandsEditor.UserControls
{
    public partial class BaseUserControl : UserControl
    {
        protected LevelContent Content => Singleton.Editor?.CommandsDisplay?.Content;

        public BaseUserControl()
        {
            InitializeComponent();
        }
    }
}
