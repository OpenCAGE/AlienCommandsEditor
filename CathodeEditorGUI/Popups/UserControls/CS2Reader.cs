﻿using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using CATHODE.LEGACY;
using static CATHODE.LEGACY.CathodeModels;
using System.Numerics;
using CATHODE.Misc;
using System.Runtime.InteropServices;
using System.Drawing;
using CATHODE.Assets;

namespace CathodeEditorGUI.Popups.UserControls
{
    public class CS2Reader : IModelReader
    {
        public Model3DGroup Read(int ModelIndex)
        {
            Model3DGroup modelGroup = new Model3DGroup();
            ModelData ChunkArray = CurrentInstance.modelDB.Models[ModelIndex];
            for (int ChunkIndex = 0; ChunkIndex < ChunkArray.Header.SubmeshCount; ++ChunkIndex)
            {
                int BINIndex = ChunkArray.Submeshes[ChunkIndex].binIndex;
                alien_model_bin_model_info Model = CurrentInstance.modelDB.modelBIN.Models[BINIndex];
                //if (Model.BlockSize == 0) continue;

                alien_vertex_buffer_format VertexInput = CurrentInstance.modelDB.modelBIN.VertexBufferFormats[Model.VertexFormatIndex];
                alien_vertex_buffer_format VertexInputLowDetail = CurrentInstance.modelDB.modelBIN.VertexBufferFormats[Model.VertexFormatIndexLowDetail];

                BinaryReader Stream = new BinaryReader(new MemoryStream(ChunkArray.Submeshes[ChunkIndex].content));

                List<List<alien_vertex_buffer_format_element>> Elements = new List<List<alien_vertex_buffer_format_element>>();
                alien_vertex_buffer_format_element ElementHeader = new alien_vertex_buffer_format_element();
                foreach (alien_vertex_buffer_format_element Element in VertexInput.Elements)
                {
                    if (Element.ArrayIndex == 0xFF)
                    {
                        ElementHeader = Element;
                        continue;
                    }

                    while (Elements.Count - 1 < Element.ArrayIndex) Elements.Add(new List<alien_vertex_buffer_format_element>());
                    Elements[Element.ArrayIndex].Add(Element);
                }
                Elements.Add(new List<alien_vertex_buffer_format_element>() { ElementHeader });

                Int32Collection InIndices = new Int32Collection();
                Point3DCollection InVertices = new Point3DCollection();
                Vector3DCollection InNormals = new Vector3DCollection();
                List<Vector4> InTangents = new List<Vector4>();
                PointCollection InUVs0 = new PointCollection();
                PointCollection InUVs1 = new PointCollection();
                PointCollection InUVs2 = new PointCollection();
                PointCollection InUVs3 = new PointCollection();
                PointCollection InUVs7 = new PointCollection();

                //TODO: implement skeleton lookup for the indexes
                List<Vector4> InBoneIndexes = new List<Vector4>(); //The indexes of 4 bones that affect each vertex
                List<Vector4> InBoneWeights = new List<Vector4>(); //The weights for each bone

                for (int VertexArrayIndex = 0; VertexArrayIndex < Elements.Count; ++VertexArrayIndex)
                {
                    alien_vertex_buffer_format_element Inputs = Elements[VertexArrayIndex][0];
                    if (Inputs.ArrayIndex == 0xFF)
                    {
                        for (int i = 0; i < Model.IndexCount; i++)
                        {
                            InIndices.Add(Stream.ReadUInt16());
                        }
                    }
                    else
                    {
                        for (int VertexIndex = 0; VertexIndex < Model.VertexCount; ++VertexIndex)
                        {
                            for (int ElementIndex = 0; ElementIndex < Elements[VertexArrayIndex].Count; ++ElementIndex)
                            {
                                alien_vertex_buffer_format_element Input = Elements[VertexArrayIndex][ElementIndex];
                                switch (Input.VariableType)
                                {
                                    case alien_vertex_input_type.AlienVertexInputType_v3:
                                        {
                                            Vector3D Value = new Vector3D(Stream.ReadSingle(), Stream.ReadSingle(), Stream.ReadSingle());
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_N:
                                                    InNormals.Add(Value);
                                                    break;
                                                case alien_vertex_input_slot.AlienVertexInputSlot_T:
                                                    InTangents.Add(new Vector4((float)Value.X, (float)Value.Y, (float)Value.Z, 0));
                                                    break;
                                                case alien_vertex_input_slot.AlienVertexInputSlot_UV:
                                                    //TODO: 3D UVW
                                                    break;
                                            };
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_u32_C:
                                        {
                                            int Value = Stream.ReadInt32();
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_C:
                                                    //??
                                                    break;
                                            }
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_v4u8_i:
                                        {
                                            Vector4 Value = new Vector4(Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte());
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_BI:
                                                    InBoneIndexes.Add(Value);
                                                    break;
                                            }
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_v4u8_f:
                                        {
                                            Vector4 Value = new Vector4(Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte());
                                            Value /= 255.0f;
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_BW:
                                                    float Sum = Value.X + Value.Y + Value.Z + Value.W;
                                                    InBoneWeights.Add(Value / Sum);
                                                    break;
                                                case alien_vertex_input_slot.AlienVertexInputSlot_UV:
                                                    InUVs2.Add(new System.Windows.Point(Value.X, Value.Y));
                                                    InUVs3.Add(new System.Windows.Point(Value.Z, Value.W));
                                                    break;
                                            }
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_v2s16_UV:
                                        {
                                            System.Windows.Point Value = new System.Windows.Point(Stream.ReadInt16() / 2048.0f, Stream.ReadInt16() / 2048.0f);
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_UV:
                                                    if (Input.VariantIndex == 0) InUVs0.Add(Value);
                                                    else if (Input.VariantIndex == 1)
                                                    {
                                                        // TODO: We can figure this out based on alien_vertex_buffer_format_element.
                                                        //Material->Material.Flags |= Material_HasTexCoord1;
                                                        InUVs1.Add(Value);
                                                    }
                                                    else if (Input.VariantIndex == 2) InUVs2.Add(Value);
                                                    else if (Input.VariantIndex == 3) InUVs3.Add(Value);
                                                    else if (Input.VariantIndex == 7) InUVs7.Add(Value);
                                                    break;
                                            }
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_v4s16_f:
                                        {
                                            Vector4 Value = new Vector4(Stream.ReadInt16(), Stream.ReadInt16(), Stream.ReadInt16(), Stream.ReadInt16());
                                            Value /= (float)Int16.MaxValue;
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_P:
                                                    InVertices.Add(new Point3D(Value.X, Value.Y, Value.Z));
                                                    break;
                                            }
                                            break;
                                        }

                                    case alien_vertex_input_type.AlienVertexInputType_v4u8_NTB:
                                        {
                                            Vector4 Value = new Vector4(Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte(), Stream.ReadByte());
                                            Value /= (float)byte.MaxValue - 0.5f;
                                            Value = Vector4.Normalize(Value);
                                            switch (Input.ShaderSlot)
                                            {
                                                case alien_vertex_input_slot.AlienVertexInputSlot_N:
                                                    InNormals.Add(new Vector3D(Value.X, Value.Y, Value.Z));
                                                    break;
                                                case alien_vertex_input_slot.AlienVertexInputSlot_T:
                                                    break;
                                                case alien_vertex_input_slot.AlienVertexInputSlot_B:
                                                    break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    CATHODE.Utilities.Align(Stream, 16);
                }

                if (InVertices.Count == 0) continue;

                Material material = HelixToolkit.Wpf.Materials.Yellow;
                MaterialTextureReference[] textures = CurrentInstance.materialDB.Materials[Model.MaterialLibraryIndex].TextureReferences;
                if (textures.Length > 0)
                {
                    for (int i = CurrentInstance.materialDB.Materials[Model.MaterialLibraryIndex].TextureReferences.Length - 1; i >= 0; i--) 
                    {
                        try
                        {

                            if (CurrentInstance.materialDB.Materials[Model.MaterialLibraryIndex].MaterialIndex != Model.MaterialLibraryIndex)
                            {
                                string bleh = "";
                            }

                            int tableIndex = CurrentInstance.materialDB.Materials[Model.MaterialLibraryIndex].TextureReferences[i].TextureTableIndex;
                            Textures texDB = CurrentInstance.textureDB;
                            if (tableIndex == 2) texDB = CurrentInstance.textureDB_Global;

                            string texFileName = texDB.GetFileNames()[CurrentInstance.materialDB.Materials[Model.MaterialLibraryIndex].TextureReferences[i].TextureIndex];

                            texDB.ExportFile(Path.GetFileNameWithoutExtension(texFileName) + ".dds", texFileName);
                            Bitmap bmp = GetAsBitmap(Path.GetFileNameWithoutExtension(texFileName) + ".dds");
                            if (bmp == null) continue;
                            bmp.Save(Path.GetFileNameWithoutExtension(texFileName) + ".png");
                            material = HelixToolkit.Wpf.MaterialHelper.CreateImageMaterial(Path.GetFileNameWithoutExtension(texFileName) + ".png");

                            break;
                        }
                        catch { }
                    }
                }

                modelGroup.Children.Add(new GeometryModel3D
                {
                    Geometry = new MeshGeometry3D
                    {
                        Positions = InVertices,
                        TriangleIndices = InIndices,
                        Normals = InNormals,
                        TextureCoordinates = InUVs0
                    },
                    Material = material,
                    BackMaterial = material,
                });
            }
            return modelGroup;
        }

        /* Convert a DDS file to System Bitmap */
        private Bitmap GetAsBitmap(string FileName)
        {
            Bitmap toReturn = null;
            if (Path.GetExtension(FileName).ToUpper() != ".DDS") return toReturn;

            try
            {
                MemoryStream imageStream = new MemoryStream(File.ReadAllBytes(FileName));
                using (var image = Pfim.Pfim.FromStream(imageStream))
                {
                    System.Drawing.Imaging.PixelFormat format = System.Drawing.Imaging.PixelFormat.DontCare;
                    switch (image.Format)
                    {
                        case Pfim.ImageFormat.Rgba32:
                            format = System.Drawing.Imaging.PixelFormat.Format32bppArgb;
                            break;
                        case Pfim.ImageFormat.Rgb24:
                            format = System.Drawing.Imaging.PixelFormat.Format24bppRgb;
                            break;
                        default:
                            Console.WriteLine("Unsupported DDS: " + image.Format);
                            break;
                    }
                    if (format != System.Drawing.Imaging.PixelFormat.DontCare)
                    {
                        var handle = GCHandle.Alloc(image.Data, GCHandleType.Pinned);
                        try
                        {
                            var data = Marshal.UnsafeAddrOfPinnedArrayElement(image.Data, 0);
                            toReturn = new Bitmap(image.Width, image.Height, image.Stride, format, data);
                        }
                        finally
                        {
                            handle.Free();
                        }
                    }
                }
            }
            catch { }

            return toReturn;
        }

        public Model3DGroup Read(string path)
        {
            throw new NotImplementedException();
        }

        public Model3DGroup Read(Stream s)
        {
            throw new NotImplementedException();
        }
    }
}