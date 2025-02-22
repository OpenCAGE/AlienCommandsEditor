﻿using CATHODE;
using CATHODE.Scripting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommandsEditor.Popups.UserControls;
using System.Windows.Interop;
using CommandsEditor.Popups.Base;
using CATHODE.EXPERIMENTAL;
using CommandsEditor.DockPanels;

namespace CommandsEditor
{
    //TODO: this whole resource editor needs a bit of a rework & improvement as it's not good enough.

    public partial class AddOrEditResource : BaseWindow
    {
        public Action<List<ResourceReference>> OnSaved;
        
        private List<ResourceReference> resources = null;
        private ShortGuid guid_parent;
        private int current_ui_offset = 7;

        private EntityInspector _entDisplay = null;

        public AddOrEditResource(EntityInspector entDisplay) : base(WindowClosesOn.COMMANDS_RELOAD | WindowClosesOn.NEW_ENTITY_SELECTION | WindowClosesOn.NEW_COMPOSITE_SELECTION)
        {
            _entDisplay = entDisplay;

            List<ResourceReference> resRefs = ((FunctionEntity)entDisplay.Entity).resources;
            ResourceReference[] copy = new ResourceReference[resRefs.Count];
            resRefs.CopyTo(copy);
            resources = copy.ToList<ResourceReference>();
            guid_parent = entDisplay.Entity.shortGUID;

            InitializeComponent();

            this.Text += " - " + Content.editor_utils.GenerateEntityName(entDisplay.Entity, entDisplay.Composite);
            resourceType.SelectedIndex = 0;

            RefreshUI();
        }

        public AddOrEditResource(EntityInspector entDisplay, List<ResourceReference> resRefs, ShortGuid parent, string windowTitle) : base(WindowClosesOn.COMMANDS_RELOAD | WindowClosesOn.NEW_ENTITY_SELECTION | WindowClosesOn.NEW_COMPOSITE_SELECTION)
        {
            _entDisplay = entDisplay;

            ResourceReference[] copy = new ResourceReference[resRefs.Count];
            resRefs.CopyTo(copy);
            resources = copy.ToList<ResourceReference>();
            guid_parent = parent;

            InitializeComponent();

            this.Text += " - " + windowTitle;
            resourceType.SelectedIndex = 0;

            RefreshUI();
        }

        private void RefreshUI()
        {
            current_ui_offset = 7;
            resource_panel.Controls.Clear();

            for (int i = 0; i < resources.Count; i++)
            {
                ResourceUserControl resourceGroup = null;
                switch (resources[i].resource_type)
                {
                    case ResourceType.ANIMATED_MODEL:
                        {
                            resourceGroup = new GUI_Resource_AnimatedModel();
                            ((GUI_Resource_AnimatedModel)resourceGroup).PopulateUI(Content.resource.env_animations.Entries.FirstOrDefault(o => o.ResourceIndex == resources[i].index));
                            break;
                        }
                    case ResourceType.COLLISION_MAPPING:
                        {
                            //TODO: Pass this info through, and handle making new instances...
                            Content.resource.collision_maps.Entries.FindAll(o => o.entity.entity_id == resources[i].entityID);

                            resourceGroup = new GUI_Resource_CollisionMapping();
                            ((GUI_Resource_CollisionMapping)resourceGroup).PopulateUI(resources[i].position, resources[i].rotation, resources[i].entityID);
                            break;
                        }
                    case ResourceType.NAV_MESH_BARRIER_RESOURCE:
                        {
                            resourceGroup = new GUI_Resource_NavMeshBarrierResource();
                            ((GUI_Resource_NavMeshBarrierResource)resourceGroup).PopulateUI(resources[i].position, resources[i].rotation);
                            break;
                        }
                    case ResourceType.RENDERABLE_INSTANCE:
                        {
                            resourceGroup = new GUI_Resource_RenderableInstance();
                            ((GUI_Resource_RenderableInstance)resourceGroup).PopulateUI(resources[i].position, resources[i].rotation, resources[i].index, resources[i].count);
                            break;
                        }
                        /*
                    case ResourceType.DYNAMIC_PHYSICS_SYSTEM:
                        {
                            //TODO: Pass this info through, and handle making new instances...
                            Content.resource.physics_maps.Entries.FindAll(o => o.entity.entity_id == resources[i].collisionID);

                            resourceGroup = new GUI_Resource_DynamicPhysicsSystem();
                            ((GUI_Resource_DynamicPhysicsSystem)resourceGroup).PopulateUI(_entDisplay, resources[i].index); 
                            break;
                        }
                        */
                    default:
                        {
                            resourceGroup = new GUI_Resource_Default();
                            ((GUI_Resource_Default)resourceGroup).PopulateUI(resources[i].resource_type);
                            break;
                        }
                }
                resourceGroup.ResourceReference = resources[i];
                resourceGroup.Location = new Point(15, current_ui_offset);
                current_ui_offset += resourceGroup.Height + 6;
                resource_panel.Controls.Add(resourceGroup);
            }
        }

        /* Add a new resource reference to the list */
        private void addResource_Click(object sender, EventArgs e)
        {
            ResourceType type = (ResourceType)Enum.Parse(typeof(ResourceType), resourceType.Items[resourceType.SelectedIndex].ToString());

            //If we don't have EntityDisplay, we can't make DynamicPhysicsSystem: this is the result of this editor being made in a crap way. really we should probs implicitly handle the resource parameter
            if (type == ResourceType.DYNAMIC_PHYSICS_SYSTEM && _entDisplay == null)
            {
                MessageBox.Show("Dynamic Physics Systems cannot currently be added as Resource parameters.", "Currently unsupported.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //A resource reference list can only ever point to one of a type
            for (int i = 0; i < resources.Count; i++)
            {
                if (resources[i].resource_type == type)
                {
                    MessageBox.Show("This resource type is already referenced!\nOnly one reference to " + type + " can be added.", "Can't add duplicate type.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            ResourceReference newReference = new ResourceReference();
            newReference.resource_id = guid_parent;
            newReference.resource_type = type;
            switch (newReference.resource_type)
            {
                case ResourceType.DYNAMIC_PHYSICS_SYSTEM:
                case ResourceType.RENDERABLE_INSTANCE:
                case ResourceType.ANIMATED_MODEL: 
                    newReference.index = 0;
                    break;            
                case ResourceType.EXCLUSIVE_MASTER_STATE_RESOURCE:
                    //TODO: this defines the MASTER_STATE which flips us between the STATE_x folders for navmeshes, etc -> how do we know the state index?
                case ResourceType.NAV_MESH_BARRIER_RESOURCE:      
                case ResourceType.TRAVERSAL_SEGMENT:              //Sure this one doesn't use startIndex?
                case ResourceType.COLLISION_MAPPING:              //Sure this one doesn't use startIndex?
                    //This type just uses the default values
                    break;
            }

            //We now auto create ANIMATED_MODEL entries. We should probs do the same for others too.
            if (newReference.resource_type == ResourceType.ANIMATED_MODEL)
            {
                if (Content.resource.env_animations.Entries.Count == 0)
                {
                    MessageBox.Show("Cannot add ANIMATED_MODEL for a level with no Environment Animations!");
                    return;
                }

                EnvironmentAnimations.EnvironmentAnimation anim = new EnvironmentAnimations.EnvironmentAnimation();
                anim.ResourceIndex = Content.resource.env_animations.Entries[Content.resource.env_animations.Entries.Count - 1].ResourceIndex + 1;
                Content.resource.env_animations.Entries.Add(anim);

                newReference.index = anim.ResourceIndex;
            }

            resources.Add(newReference);

            RefreshUI();
        }

        /* Delete an existing resource reference from the list */
        private void deleteResource_Click(object sender, EventArgs e)
        {
            ResourceType type = (ResourceType)Enum.Parse(typeof(ResourceType), resourceType.Items[resourceType.SelectedIndex].ToString());
            ResourceReference reference = resources.FirstOrDefault(o => o.resource_type == type);
            if (reference == null)
            {
                MessageBox.Show("Resource type " + type + " is not referenced!\nThere is nothing to delete.", "Type not referenced!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (MessageBox.Show("You are about to remove resource reference for type " + type + ".\nThis is a destructive action - are you sure?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    resources.Remove(reference);
                    RefreshUI();
                }
            }
        }

        /* Save all changes back out */
        private void SaveChanges_Click(object sender, EventArgs e)
        {
            List<ResourceReference> newResourceReferences = new List<ResourceReference>();
            for (int i = 0; i < resource_panel.Controls.Count; i++)
            {
                ResourceReference resourceRef = ((ResourceUserControl)resource_panel.Controls[i]).ResourceReference;
                switch (resourceRef.resource_type)
                {
                    case ResourceType.ANIMATED_MODEL:
                        {
                            GUI_Resource_AnimatedModel ui = (GUI_Resource_AnimatedModel)resource_panel.Controls[i];
                            //resourceRef.index = ui.EnvironmentAnimIndex; <- we now just use direct objects rather than index
                            break;
                        }
                    case ResourceType.COLLISION_MAPPING:
                        {
                            GUI_Resource_CollisionMapping ui = (GUI_Resource_CollisionMapping)resource_panel.Controls[i];
                            resourceRef.position = ui.Position;
                            resourceRef.rotation = ui.Rotation;
                            resourceRef.entityID = ui.CollisionEnabled ? _entDisplay.Entity.shortGUID : new ShortGuid("FF-FF-FF-FF");
                            break;
                        }
                    case ResourceType.NAV_MESH_BARRIER_RESOURCE:
                        {
                            GUI_Resource_NavMeshBarrierResource ui = (GUI_Resource_NavMeshBarrierResource)resource_panel.Controls[i];
                            resourceRef.position = ui.Position;
                            resourceRef.rotation = ui.Rotation;
                            break;
                        }
                    case ResourceType.RENDERABLE_INSTANCE:
                        {
                            GUI_Resource_RenderableInstance ui = (GUI_Resource_RenderableInstance)resource_panel.Controls[i];
                            resourceRef.position = ui.Position;
                            resourceRef.rotation = ui.Rotation;
                            resourceRef.count = ui.SelectedMaterialIndexes.Count;
                            resourceRef.index = Content.resource.reds.Entries.Count;

                            for (int y = 0; y < ui.SelectedMaterialIndexes.Count; y++)
                            {
                                RenderableElements.Element newRed = new RenderableElements.Element();
                                newRed.ModelIndex = ui.SelectedModelIndex + y; //assumes sequential write
                                newRed.MaterialIndex = ui.SelectedMaterialIndexes[y];
                                if (y == 0)
                                {
                                    newRed.LODIndex = Content.resource.reds.Entries.Count;
                                    //newRed.LODCount = (byte)ui.SelectedMaterialIndexes.Count;
                                    newRed.LODCount = 0; //TODO!!
                                }
                                Content.resource.reds.Entries.Add(newRed);
                            }
                            break;
                        }
                }
                newResourceReferences.Add(resourceRef);
            }
            resources = newResourceReferences;
            OnSaved?.Invoke(resources);
            this.Close();
        }
    }
}
