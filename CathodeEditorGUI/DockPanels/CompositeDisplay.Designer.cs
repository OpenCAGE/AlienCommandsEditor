namespace CommandsEditor.DockPanels
{
    partial class CompositeDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Variables", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Functions", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Proxies", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("Alias", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompositeDisplay));
            this.composite_content = new System.Windows.Forms.ListView();
            this.EntityName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntityType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entity_search_box = new System.Windows.Forms.TextBox();
            this.entity_search_btn = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.createEntity = new System.Windows.Forms.ToolStripDropDownButton();
            this.createVariableEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFunctionEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCompositeEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createProxyEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOverrideEntityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportComposite = new System.Windows.Forms.ToolStripButton();
            this.findUses = new System.Windows.Forms.ToolStripButton();
            this.deleteCheckedEntities = new System.Windows.Forms.ToolStripButton();
            this.deleteComposite = new System.Windows.Forms.ToolStripButton();
            this.vS2015DarkTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.vS2015BlueTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.vS2015LightTheme1 = new WeifenLuo.WinFormsUI.Docking.VS2015LightTheme();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeAll = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllBut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // composite_content
            // 
            this.composite_content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.composite_content.CheckBoxes = true;
            this.composite_content.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.EntityName,
            this.EntityType});
            this.composite_content.FullRowSelect = true;
            listViewGroup1.Header = "Variables";
            listViewGroup1.Name = "Variables";
            listViewGroup2.Header = "Functions";
            listViewGroup2.Name = "Functions";
            listViewGroup3.Header = "Proxies";
            listViewGroup3.Name = "Proxies";
            listViewGroup4.Header = "Alias";
            listViewGroup4.Name = "Alias";
            this.composite_content.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4});
            this.composite_content.HideSelection = false;
            this.composite_content.LabelWrap = false;
            this.composite_content.Location = new System.Drawing.Point(3, 30);
            this.composite_content.MultiSelect = false;
            this.composite_content.Name = "composite_content";
            this.composite_content.Size = new System.Drawing.Size(827, 766);
            this.composite_content.TabIndex = 176;
            this.composite_content.UseCompatibleStateImageBehavior = false;
            this.composite_content.View = System.Windows.Forms.View.Details;
            this.composite_content.SelectedIndexChanged += new System.EventHandler(this.composite_content_SelectedIndexChanged);
            // 
            // EntityName
            // 
            this.EntityName.Text = "Name";
            this.EntityName.Width = 279;
            // 
            // EntityType
            // 
            this.EntityType.Text = "Type";
            this.EntityType.Width = 163;
            // 
            // entity_search_box
            // 
            this.entity_search_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entity_search_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.entity_search_box.Location = new System.Drawing.Point(3, 4);
            this.entity_search_box.Name = "entity_search_box";
            this.entity_search_box.Size = new System.Drawing.Size(766, 20);
            this.entity_search_box.TabIndex = 146;
            // 
            // entity_search_btn
            // 
            this.entity_search_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.entity_search_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.entity_search_btn.Location = new System.Drawing.Point(767, 4);
            this.entity_search_btn.Name = "entity_search_btn";
            this.entity_search_btn.Size = new System.Drawing.Size(63, 20);
            this.entity_search_btn.TabIndex = 145;
            this.entity_search_btn.Text = "Search";
            this.entity_search_btn.UseVisualStyleBackColor = true;
            this.entity_search_btn.Click += new System.EventHandler(this.entity_search_btn_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createEntity,
            this.exportComposite,
            this.findUses,
            this.deleteCheckedEntities,
            this.deleteComposite});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1615, 25);
            this.toolStrip1.TabIndex = 177;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createEntity
            // 
            this.createEntity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createVariableEntityToolStripMenuItem,
            this.createFunctionEntityToolStripMenuItem,
            this.createCompositeEntityToolStripMenuItem,
            this.createProxyEntityToolStripMenuItem,
            this.createOverrideEntityToolStripMenuItem});
            this.createEntity.Image = ((System.Drawing.Image)(resources.GetObject("createEntity.Image")));
            this.createEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createEntity.Name = "createEntity";
            this.createEntity.Size = new System.Drawing.Size(103, 22);
            this.createEntity.Text = "Create Entity";
            this.createEntity.Click += new System.EventHandler(this.createEntity_Click);
            // 
            // createVariableEntityToolStripMenuItem
            // 
            this.createVariableEntityToolStripMenuItem.Name = "createVariableEntityToolStripMenuItem";
            this.createVariableEntityToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createVariableEntityToolStripMenuItem.Text = "Create Variable Entity";
            this.createVariableEntityToolStripMenuItem.ToolTipText = "Create an entity which can contain a variable";
            this.createVariableEntityToolStripMenuItem.Click += new System.EventHandler(this.createVariableEntityToolStripMenuItem_Click);
            // 
            // createFunctionEntityToolStripMenuItem
            // 
            this.createFunctionEntityToolStripMenuItem.Name = "createFunctionEntityToolStripMenuItem";
            this.createFunctionEntityToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createFunctionEntityToolStripMenuItem.Text = "Create Function Entity";
            this.createFunctionEntityToolStripMenuItem.ToolTipText = "Create an entity that can perform a function";
            this.createFunctionEntityToolStripMenuItem.Click += new System.EventHandler(this.createFunctionEntityToolStripMenuItem_Click);
            // 
            // createCompositeEntityToolStripMenuItem
            // 
            this.createCompositeEntityToolStripMenuItem.Name = "createCompositeEntityToolStripMenuItem";
            this.createCompositeEntityToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createCompositeEntityToolStripMenuItem.Text = "Create Composite Entity";
            this.createCompositeEntityToolStripMenuItem.ToolTipText = "Create an entity that instances a composite";
            this.createCompositeEntityToolStripMenuItem.Click += new System.EventHandler(this.createCompositeEntityToolStripMenuItem_Click);
            // 
            // createProxyEntityToolStripMenuItem
            // 
            this.createProxyEntityToolStripMenuItem.Name = "createProxyEntityToolStripMenuItem";
            this.createProxyEntityToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createProxyEntityToolStripMenuItem.Text = "Create Proxy";
            this.createProxyEntityToolStripMenuItem.ToolTipText = "Create an entity that acts as a proxy to an entity in another composite";
            this.createProxyEntityToolStripMenuItem.Click += new System.EventHandler(this.createProxyEntityToolStripMenuItem_Click);
            // 
            // createOverrideEntityToolStripMenuItem
            // 
            this.createOverrideEntityToolStripMenuItem.Name = "createOverrideEntityToolStripMenuItem";
            this.createOverrideEntityToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.createOverrideEntityToolStripMenuItem.Text = "Create Alias";
            this.createOverrideEntityToolStripMenuItem.ToolTipText = "Create an alias that points to an entity in a child composite";
            this.createOverrideEntityToolStripMenuItem.Click += new System.EventHandler(this.createOverrideEntityToolStripMenuItem_Click);
            // 
            // exportComposite
            // 
            this.exportComposite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exportComposite.Image = ((System.Drawing.Image)(resources.GetObject("exportComposite.Image")));
            this.exportComposite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportComposite.Name = "exportComposite";
            this.exportComposite.Size = new System.Drawing.Size(110, 22);
            this.exportComposite.Text = "Port Composite";
            this.exportComposite.Click += new System.EventHandler(this.exportComposite_Click);
            // 
            // findUses
            // 
            this.findUses.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.findUses.Image = ((System.Drawing.Image)(resources.GetObject("findUses.Image")));
            this.findUses.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findUses.Name = "findUses";
            this.findUses.Size = new System.Drawing.Size(177, 22);
            this.findUses.Text = "Find Instances of Composite";
            this.findUses.Click += new System.EventHandler(this.findUses_Click);
            // 
            // deleteCheckedEntities
            // 
            this.deleteCheckedEntities.Image = ((System.Drawing.Image)(resources.GetObject("deleteCheckedEntities.Image")));
            this.deleteCheckedEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteCheckedEntities.Name = "deleteCheckedEntities";
            this.deleteCheckedEntities.Size = new System.Drawing.Size(150, 22);
            this.deleteCheckedEntities.Text = "Delete Checked Entities";
            this.deleteCheckedEntities.Click += new System.EventHandler(this.deleteCheckedEntities_Click);
            // 
            // deleteComposite
            // 
            this.deleteComposite.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.deleteComposite.Image = ((System.Drawing.Image)(resources.GetObject("deleteComposite.Image")));
            this.deleteComposite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteComposite.Name = "deleteComposite";
            this.deleteComposite.Size = new System.Drawing.Size(121, 22);
            this.deleteComposite.Text = "Delete Composite";
            this.deleteComposite.Click += new System.EventHandler(this.deleteComposite_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DockBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.dockPanel.Location = new System.Drawing.Point(0, 0);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.Padding = new System.Windows.Forms.Padding(6);
            this.dockPanel.ShowAutoHideContentOnHover = false;
            this.dockPanel.Size = new System.Drawing.Size(781, 796);
            this.dockPanel.TabIndex = 178;
            this.dockPanel.Theme = this.vS2015BlueTheme1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.composite_content);
            this.panel1.Controls.Add(this.entity_search_box);
            this.panel1.Controls.Add(this.entity_search_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 796);
            this.panel1.TabIndex = 180;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dockPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1615, 796);
            this.splitContainer1.SplitterDistance = 830;
            this.splitContainer1.TabIndex = 182;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "flag_blue");
            this.imageList.Images.SetKeyName(1, "flag_green");
            this.imageList.Images.SetKeyName(2, "flag_red");
            this.imageList.Images.SetKeyName(3, "behavior");
            this.imageList.Images.SetKeyName(4, "behavior_loaded");
            this.imageList.Images.SetKeyName(5, "behavior_modified");
            this.imageList.Images.SetKeyName(6, "condition");
            this.imageList.Images.SetKeyName(7, "impulse");
            this.imageList.Images.SetKeyName(8, "action");
            this.imageList.Images.SetKeyName(9, "decorator");
            this.imageList.Images.SetKeyName(10, "sequence");
            this.imageList.Images.SetKeyName(11, "selector");
            this.imageList.Images.SetKeyName(12, "parallel");
            this.imageList.Images.SetKeyName(13, "folder_closed");
            this.imageList.Images.SetKeyName(14, "folder_open");
            this.imageList.Images.SetKeyName(15, "event");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAll,
            this.closeSelected,
            this.closeAllBut});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 70);
            // 
            // closeAll
            // 
            this.closeAll.Image = ((System.Drawing.Image)(resources.GetObject("closeAll.Image")));
            this.closeAll.Name = "closeAll";
            this.closeAll.Size = new System.Drawing.Size(249, 22);
            this.closeAll.Text = "Close All Composites";
            this.closeAll.Click += new System.EventHandler(this.closeAll_Click);
            // 
            // closeSelected
            // 
            this.closeSelected.Image = ((System.Drawing.Image)(resources.GetObject("closeSelected.Image")));
            this.closeSelected.Name = "closeSelected";
            this.closeSelected.Size = new System.Drawing.Size(249, 22);
            this.closeSelected.Text = "Close Selected Composite";
            this.closeSelected.Click += new System.EventHandler(this.closeSelected_Click);
            // 
            // closeAllBut
            // 
            this.closeAllBut.Image = ((System.Drawing.Image)(resources.GetObject("closeAllBut.Image")));
            this.closeAllBut.Name = "closeAllBut";
            this.closeAllBut.Size = new System.Drawing.Size(249, 22);
            this.closeAllBut.Text = "Close All But Selected Composite";
            this.closeAllBut.Click += new System.EventHandler(this.closeAllBut_Click);
            // 
            // CompositeDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1615, 821);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompositeDisplay";
            this.TabPageContextMenuStrip = this.contextMenuStrip1;
            this.Text = "Selected Composite";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView composite_content;
        private System.Windows.Forms.ColumnHeader EntityName;
        private System.Windows.Forms.ColumnHeader EntityType;
        private System.Windows.Forms.TextBox entity_search_box;
        private System.Windows.Forms.Button entity_search_btn;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private WeifenLuo.WinFormsUI.Docking.VS2015DarkTheme vS2015DarkTheme1;
        private System.Windows.Forms.ToolStripButton findUses;
        private System.Windows.Forms.ToolStripButton deleteComposite;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.Panel panel1;
        private WeifenLuo.WinFormsUI.Docking.VS2015BlueTheme vS2015BlueTheme1;
        private WeifenLuo.WinFormsUI.Docking.VS2015LightTheme vS2015LightTheme1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton deleteCheckedEntities;
        private System.Windows.Forms.ToolStripButton exportComposite;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeSelected;
        private System.Windows.Forms.ToolStripMenuItem closeAll;
        private System.Windows.Forms.ToolStripMenuItem closeAllBut;
        private System.Windows.Forms.ToolStripDropDownButton createEntity;
        private System.Windows.Forms.ToolStripMenuItem createVariableEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createFunctionEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCompositeEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createProxyEntityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createOverrideEntityToolStripMenuItem;
    }
}