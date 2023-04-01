﻿using CATHODE;
using CATHODE.Scripting;
using CATHODE.Scripting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsEditor
{
    /* TODO: DEPRECATE THIS IN FAVOUR OF A SOLUTION IN THE LIBRARY */

    //NOTE TO SELF: this db is dumped by the cathode_vartype tool in isolation_testground

    public static class CathodeEntityDatabase
    {
        public struct EntityDefinition
        {
            public string guidName;
            public ShortGuid guid;
            public string className;
            public bool isEntity; //if false, this is a template
            public List<ParameterDefinition> parameters;
        }
        public struct ParameterDefinition
        {
            public string name;
            public string variable;
            public ParameterUsage usage;
            public string datatype; //todo:turn in to enum
        }
        public enum ParameterUsage
        {
            TARGET,
            STATE,
            INPUT,
            OUTPUT,
            PARAMETER,
            INTERNAL,

            REFERENCE, // <- this isn't actually a usage, but EntityMethodInterface seems to give this functionality to all entities

            METHOD,
            FINISHED,
            RELAY,
        }
        public enum ParameterDatatype
        {
            //wip
            INT,
            FLOAT,
            BOOL,
            STRING, //CATHODE:String
            DIRECTION, //CA::Vector

        }

        private static List<EntityDefinition> entities = new List<EntityDefinition>();
        static CathodeEntityDatabase()
        {
            MemoryStream readerStream = new MemoryStream(Properties.Resources.cathode_entities);
            BinaryReader reader = new BinaryReader(readerStream);
            int entry_count = reader.ReadInt32();
            for (int i = 0; i < entry_count; i++)
            {
                EntityDefinition entityDefinition = new EntityDefinition();
                entityDefinition.guidName = reader.ReadString().Replace(@"\\", @"\");
                entityDefinition.guid = ShortGuidUtils.Generate(entityDefinition.guidName);
                entityDefinition.className = reader.ReadString();
                entityDefinition.isEntity = reader.ReadBoolean();
                entityDefinition.parameters = new List<ParameterDefinition>();
                int param_count = reader.ReadInt32();
                for (int x = 0; x < param_count; x++)
                {
                    ParameterDefinition parameterDefinition = new ParameterDefinition();
                    parameterDefinition.name = reader.ReadString();
                    parameterDefinition.variable = reader.ReadString();
                    parameterDefinition.usage = (ParameterUsage)Enum.Parse(typeof(ParameterUsage), reader.ReadString().ToUpper());
                    parameterDefinition.datatype = reader.ReadString();

                    //TODO: this is a hotfix to hide the "name" param on all entities except zones, as i think this is the value that compiles to the string we handle via EntityUtils
                    if (entityDefinition.className != "Zone" && parameterDefinition.name == "name") continue;

                    entityDefinition.parameters.Add(parameterDefinition);
                }
                entities.Add(entityDefinition);
            }
            entities = entities.OrderBy(o => o.className).ToList();
        }

        public static List<EntityDefinition> GetEntities(bool includeInterfaces = false)
        {
            if (!includeInterfaces)
                return entities.FindAll(o => o.isEntity);
            return entities;
        }

        public static EntityDefinition GetEntityAtIndex(int index)
        {
            return entities[index];
        }

        public static EntityDefinition GetEntity(string node_name, bool usingGuidName = true)
        {
            return entities.FirstOrDefault(o => (usingGuidName) ? o.guidName == node_name : o.className == node_name);
        }

        public static string GetEntityClassName(string node_name, bool usingGuidName = true)
        {
            return entities.FirstOrDefault(o => (usingGuidName) ? o.guidName == node_name : o.className == node_name).className;
        }
        public static string GetEntityClassName(ShortGuid node_guid)
        {
            return entities.FirstOrDefault(o => o.guid == node_guid).className;
        }

        public static List<ParameterDefinition> GetParametersFromEntity(string node_name, bool usingGuidName = true)
        {
            return entities.FirstOrDefault(o => (usingGuidName) ? o.guidName == node_name : o.className == node_name).parameters;
        }
        public static List<ParameterDefinition> GetParametersFromEntity(ShortGuid node_guid)
        {
            string node_name = GetEntityClassName(node_guid);
            return entities.FirstOrDefault(o => o.className == node_name).parameters;
        }

        public static ParameterDefinition GetParameterFromEntity(string node_name, string parameter_name, bool usingGuidName = true)
        {
            return entities.FirstOrDefault(o => (usingGuidName) ? o.guidName == node_name : o.className == node_name).parameters.FirstOrDefault(o => o.name == parameter_name);
        }
        public static ParameterDefinition GetParameterFromEntity(ShortGuid node_guid, string parameter_name)
        {
            string node_name = GetEntityClassName(node_guid);
            return entities.FirstOrDefault(o => o.className == node_name).parameters.FirstOrDefault(o => o.name == parameter_name);
        }

        public static ParameterData ParameterDefinitionToParameter(ParameterDefinition def)
        {
            ParameterData this_param = null;
            switch (def.datatype.ToUpper())
            {
                case "POSITION":
                    this_param = new cTransform();
                    break;
                case "FLOAT":
                    this_param = new cFloat();
                    break;
                case "FILEPATH":
                case "STRING":
                    this_param = new cString();
                    break;
                case "SPLINEDATA":
                    this_param = new cSpline();
                    break;
                case "BOOL":
                    this_param = new cBool();
                    break;
                case "DIRECTION":
                    this_param = new cVector3();
                    break;
                case "INT":
                    this_param = new cInteger();
                    break;
                    /*
                case "ENUM":
                    thisParam = new CathodeEnum();
                    ((CathodeEnum)thisParam).enumID = new cGUID("4C-B9-82-48"); //ALERTNESS_STATE is the first alphabetically
                    break;
                case CathodeDataType.SHORT_GUID:
                    thisParam = new CathodeResource();
                    ((CathodeResource)thisParam).resourceID = new cGUID("00-00-00-00");
                    break;
                    */
            }
            return this_param;
        }
    }
}
