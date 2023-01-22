﻿using CATHODE.Scripting;
using CathodeEditorGUI.Popups.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using CATHODE;

namespace CathodeEditorGUI
{
    public partial class CathodeEditorGUI_EditMVR : Form
    {
        private int loadedMvrIndex = -1;
        private ShortGuid filteredNodeID;

        public CathodeEditorGUI_EditMVR(ShortGuid nodeID = new ShortGuid())
        {
            InitializeComponent();

            PopulateUI(nodeID);

            renderable.OnMaterialSelected += OnMaterialSelected;
            renderable.OnModelSelected += OnModelSelected;
        }

        private void PopulateUI(ShortGuid nodeID)
        {
            filteredNodeID = nodeID;

            listBox1.BeginUpdate();
            listBox1.Items.Clear();
            for (int i = 0; i < Editor.mvr.Entries.Count; i++)
            {
                if (nodeID.val != null && Editor.mvr.Entries[i].commandsNodeID != nodeID) continue;
                listBox1.Items.Add(i.ToString());
            }
            listBox1.EndUpdate();

            if (listBox1.Items.Count != 0)
                listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadedMvrIndex = -1;
            if (listBox1.SelectedIndex == -1) return;
            LoadMVR(Convert.ToInt32(listBox1.SelectedItem.ToString()));
        }

        cTransform transformData = null;
        private bool hasLoaded = false;
        private void LoadMVR(int mvrIndex)
        {
            hasLoaded = false;
            loadedMvrIndex = mvrIndex;
            Movers.MOVER_DESCRIPTOR mvr = Editor.mvr.Entries[loadedMvrIndex];

            //Convert model BIN index from REDs to PAK index
            int pakModelIndex = -1;
            for (int y = 0; y < Editor.resource.models.Models.Count; y++)
            {
                for (int z = 0; z < Editor.resource.models.Models[y].Submeshes.Count; z++)
                {
                    if (Editor.resource.models.Models[y].Submeshes[z].binIndex == Editor.resource.reds.Entries[(int)mvr.renderableElementIndex].ModelIndex)
                    {
                        pakModelIndex = y;
                        break;
                    }
                }
                if (pakModelIndex != -1) break;
            }

            //Get all remapped materials from REDs
            List<int> modelMaterialIndexes = new List<int>();
            for (int y = 0; y < mvr.renderableElementCount; y++)
                modelMaterialIndexes.Add(Editor.resource.reds.Entries[(int)mvr.renderableElementIndex + y].MaterialIndex);
            renderable.PopulateUI(pakModelIndex, modelMaterialIndexes);

            //Load transform from matrix
            Vector3 scale;
            Quaternion rotation;
            Vector3 position;
            Matrix4x4.Decompose(mvr.transform, out scale, out rotation, out position);
            POS_X.Value = (decimal)position.X; POS_Y.Value = (decimal)position.Y; POS_Z.Value = (decimal)position.Z;
            ROT_X.Value = (decimal)rotation.X; ROT_Y.Value = (decimal)rotation.Y; ROT_Z.Value = (decimal)rotation.Z; ROT_W.Value = (decimal)rotation.W;
            SCALE_X.Value = (decimal)scale.X; SCALE_Y.Value = (decimal)scale.Y; SCALE_Z.Value = (decimal)scale.Z;

            type_dropdown.SelectedItem = mvr.instanceTypeFlags.ToString();
            hasLoaded = true;
        }

        private void saveMover_Click(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void OnMaterialSelected(int submeshIndex, int materialIndex)
        {
            SaveMVR();
        }

        private void OnModelSelected(int modelPakIndex)
        {
            SaveMVR();
        }

        private void SaveMVR()
        {
            if (!hasLoaded || loadedMvrIndex == -1) return;

            Movers.MOVER_DESCRIPTOR mvr = Editor.mvr.Entries[loadedMvrIndex];

            mvr.renderableElementCount = (uint)renderable.SelectedMaterialIndexes.Count;
            mvr.renderableElementIndex = (uint)Editor.resource.reds.Entries.Count;

            mvr.transform = Matrix4x4.CreateScale(new Vector3((float)SCALE_X.Value, (float)SCALE_Y.Value, (float)SCALE_Z.Value)) *
                            Matrix4x4.CreateFromQuaternion(new Quaternion((float)ROT_W.Value, (float)ROT_X.Value, (float)ROT_Y.Value, (float)ROT_Z.Value)) *
                            Matrix4x4.CreateTranslation(new Vector3((float)POS_X.Value, (float)POS_Y.Value, (float)POS_Z.Value));

            mvr.instanceTypeFlags = (ushort)Convert.ToInt32(type_dropdown.SelectedItem.ToString());

            Editor.mvr.Entries[loadedMvrIndex] = mvr;

            for (int y = 0; y < renderable.SelectedMaterialIndexes.Count; y++)
            {
                RenderableElements.Element newRed = new RenderableElements.Element();
                newRed.ModelIndex = Editor.resource.models.Models[renderable.SelectedModelIndex].Submeshes[y].binIndex;
                newRed.MaterialIndex = renderable.SelectedMaterialIndexes[y];
                Editor.resource.reds.Entries.Add(newRed);
            }

            Console.WriteLine("SAVED");
            //MessageBox.Show("Saved changes for mover " + loadedMvrIndex + "!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void deleteMover_Click(object sender, EventArgs e)
        {
            if (loadedMvrIndex == -1) return;
            //CurrentInstance.moverDB.Movers.RemoveAt(loadedMvrIndex);

            Editor.mvr.Entries[loadedMvrIndex] = Editor.mvr.Entries[0];

            PopulateUI(filteredNodeID);
        }

        private void POS_X_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void POS_Y_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void POS_Z_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void ROT_X_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void ROT_Y_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void ROT_Z_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void ROT_W_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void SCALE_X_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void SCALE_Y_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void SCALE_Z_ValueChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }

        private void type_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveMVR();
        }
    }
}
