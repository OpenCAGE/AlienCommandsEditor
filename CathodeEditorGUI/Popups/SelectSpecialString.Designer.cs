﻿namespace CommandsEditor
{
    partial class SelectSpecialString
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectSpecialString));
            System.Windows.Forms.ListViewGroup listViewGroup6 = new System.Windows.Forms.ListViewGroup("Parameters", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("Functions", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("Composite Instances", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("Proxies", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("Aliases", System.Windows.Forms.HorizontalAlignment.Left);
            this.clearSearchBtn = new System.Windows.Forms.Button();
            this.strings = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EntityType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.search_box = new System.Windows.Forms.TextBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clearSearchBtn
            // 
            this.clearSearchBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearSearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearSearchBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearSearchBtn.Image")));
            this.clearSearchBtn.Location = new System.Drawing.Point(739, 3);
            this.clearSearchBtn.Name = "clearSearchBtn";
            this.clearSearchBtn.Size = new System.Drawing.Size(20, 20);
            this.clearSearchBtn.TabIndex = 180;
            this.clearSearchBtn.UseVisualStyleBackColor = true;
            this.clearSearchBtn.Click += new System.EventHandler(this.clearSearchBtn_Click);
            // 
            // strings
            // 
            this.strings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.EntityType});
            this.strings.FullRowSelect = true;
            listViewGroup6.Header = "Parameters";
            listViewGroup6.Name = "Variables";
            listViewGroup7.Header = "Functions";
            listViewGroup7.Name = "Functions";
            listViewGroup8.Header = "Composite Instances";
            listViewGroup8.Name = "Composites";
            listViewGroup9.Header = "Proxies";
            listViewGroup9.Name = "Proxies";
            listViewGroup10.Header = "Aliases";
            listViewGroup10.Name = "Aliases";
            this.strings.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup6,
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10});
            this.strings.HideSelection = false;
            this.strings.LabelWrap = false;
            this.strings.Location = new System.Drawing.Point(2, 29);
            this.strings.MultiSelect = false;
            this.strings.Name = "strings";
            this.strings.Size = new System.Drawing.Size(757, 597);
            this.strings.TabIndex = 179;
            this.strings.UseCompatibleStateImageBehavior = false;
            this.strings.View = System.Windows.Forms.View.Details;
            this.strings.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ColumnClick);
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 268;
            // 
            // EntityType
            // 
            this.EntityType.Text = "Content";
            this.EntityType.Width = 469;
            // 
            // search_box
            // 
            this.search_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.search_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_box.Location = new System.Drawing.Point(2, 3);
            this.search_box.Name = "search_box";
            this.search_box.Size = new System.Drawing.Size(757, 20);
            this.search_box.TabIndex = 178;
            this.search_box.TextChanged += new System.EventHandler(this.search_box_TextChanged);
            // 
            // selectBtn
            // 
            this.selectBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.selectBtn.Location = new System.Drawing.Point(600, 634);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(151, 26);
            this.selectBtn.TabIndex = 181;
            this.selectBtn.Text = "Select";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // SelectSpecialString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 670);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.clearSearchBtn);
            this.Controls.Add(this.strings);
            this.Controls.Add(this.search_box);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SelectSpecialString";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.SelectSpecialString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearSearchBtn;
        private System.Windows.Forms.ListView strings;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader EntityType;
        private System.Windows.Forms.TextBox search_box;
        private System.Windows.Forms.Button selectBtn;
    }
}