﻿using CATHODE;
using CATHODE.Scripting;
using CATHODE.Scripting.Internal;
using CommandsEditor.Popups.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommandsEditor
{
    public partial class CAGEAnimationEditor : BaseWindow
    {
        CAGEAnimation animNode = null;
        public CAGEAnimationEditor(CAGEAnimation _node) : base(WindowClosesOn.COMMANDS_RELOAD | WindowClosesOn.NEW_ENTITY_SELECTION | WindowClosesOn.NEW_COMPOSITE_SELECTION)
        {
            animNode = _node;
            InitializeComponent();

            MessageBox.Show("The CAGEAnimation editor is still VERY early in development. It'll likely not work, or encounter issues which may corrupt your CommandsPAK, and is provided as a preview of upcoming functionality.\n\nUse it at your own risk!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            animNode.keyframeHeaders = animNode.keyframeHeaders.OrderBy(o => o.parameterID).ToList();
            string previousGroup = "";
            int groupCount = 0;
            int maxWidth = 0;
            int groupBoxOffset = 3;
            int groupHeight = 0;
            int countInGroup = 0;
            GroupBox currentGroupBox = null;
            for (int i = 0; i < animNode.keyframeHeaders.Count; i++)
            {
                string paramGroupName = ShortGuidUtils.FindString(animNode.keyframeHeaders[i].parameterID);
                if (i == 0 || previousGroup != paramGroupName)
                {
                    if (currentGroupBox != null)
                    {
                        currentGroupBox.Size = new Size(maxWidth, groupHeight);
                        groupBoxOffset += currentGroupBox.Size.Height + 10;
                    }

                    currentGroupBox = new GroupBox();
                    currentGroupBox.Text = paramGroupName;
                    currentGroupBox.Location = new Point(3, groupBoxOffset);
                    NodeParams.Controls.Add(currentGroupBox);
                    groupCount++;
                    maxWidth = 0;
                    groupHeight = 0;
                    countInGroup = 0;
                }
                previousGroup = paramGroupName;

                TextBox paramName = new TextBox();
                paramName.Text = ShortGuidUtils.FindString(animNode.keyframeHeaders[i].parameterSubID);
                paramName.ReadOnly = true;
                paramName.Location = new Point(6, 19 + (countInGroup * 23));
                paramName.Size = new Size(119, 20);
                currentGroupBox.Controls.Add(paramName);

                CAGEAnimation.Keyframe paramData = animNode.keyframeData.FirstOrDefault(o => o.ID == animNode.keyframeHeaders[i].keyframeDataID);
                //TODO: populate full min max keyframes so new ones can be created
                int keyframeWidth = paramName.Location.X + paramName.Width;
                if (paramData != null)
                {
                    for (int x = 0; x < paramData.keyframes.Count; x++)
                    {
                        Button keyframeBtn = new Button();
                        keyframeBtn.Size = new Size(27, 23);
                        keyframeBtn.Location = new Point(134 + ((keyframeBtn.Size.Width + 6) * x), 18 + (countInGroup * 23));
                        keyframeBtn.Text = paramData.keyframes[x].secondsSinceStart.ToString();
                        keyframeBtn.AccessibleDescription = paramData.ID.ToByteString() + " " + x + " " + paramName.Text;
                        keyframeBtn.Click += KeyframeBtn_Click;
                        currentGroupBox.Controls.Add(keyframeBtn);
                        if (keyframeBtn.Location.X > maxWidth) maxWidth = keyframeBtn.Location.X;
                        keyframeWidth = keyframeBtn.Location.X + keyframeBtn.Width;
                    }
                }

                Composite resolvedComposite = null;
                Entity resolvedEntity = CommandsUtils.ResolveHierarchy(Editor.commands, Editor.selected.composite, animNode.keyframeHeaders[i].connectedEntity, out resolvedComposite, out string hierarchy);
                if (resolvedEntity != null)
                {
                    TextBox controllingEntity = new TextBox();
                    controllingEntity.Text = "Controlling: " + EntityUtils.GetName(resolvedComposite.shortGUID, resolvedEntity.shortGUID);
                    controllingEntity.Location = new Point(keyframeWidth + 5, 18 + (countInGroup * 23));
                    controllingEntity.Size = new Size(200, 20);
                    controllingEntity.ReadOnly = true;
                    currentGroupBox.Controls.Add(controllingEntity);
                    int thisWidth = controllingEntity.Location.X + controllingEntity.Width + 5;
                    if (thisWidth > maxWidth) maxWidth = thisWidth;
                }

                groupHeight = paramName.Location.Y + paramName.Height + 5;
                countInGroup++;
            }
            if (currentGroupBox != null)
            {
                currentGroupBox.Size = new Size(maxWidth, groupHeight);
            }
        }

        CAGEAnimation.Keyframe.Data currentEditData = null;
        private void KeyframeBtn_Click(object sender, EventArgs e)
        {
            string info = ((Button)sender).AccessibleDescription;
            string[] infoS = info.Split(' ');
            ShortGuid id = new ShortGuid(infoS[0]);
            currentEditData = animNode.keyframeData.FirstOrDefault(o => o.ID == id).keyframes[Convert.ToInt32(infoS[1])];
            textBox2.Text = currentEditData.paramValue.ToString();
            groupBox1.Visible = true;
            string name = "";
            for (int i = 2; i < infoS.Length; i++) name += infoS[i];
            groupBox1.Text = name + ": " + currentEditData.secondsSinceStart + " seconds";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (currentEditData == null) return;
            currentEditData.paramValue = Convert.ToSingle(textBox2.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = EditorUtils.ForceStringNumeric(textBox2.Text, true);
        }
    }

    public class CAGEAnimationKeyframes
    {

    }
}
