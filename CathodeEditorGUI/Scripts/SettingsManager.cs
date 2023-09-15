﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenCAGE
{
    static class SettingsManager
    {
        static JObject _jsonConfig = null;
        static string _configPath = CommandsEditor.SharedData.pathToAI + "\\OpenCAGE Settings.json";

        static SettingsManager()
        {
            if (!File.Exists(_configPath)) _jsonConfig = new JObject { };
            else _jsonConfig = JObject.Parse(File.ReadAllText(_configPath));
        }

        /* Work out if a setting value has been previously set */
        static public bool IsSet(string name)
        {
            return _jsonConfig[name] != null;
        }

        /* Get a config variable */
        static public bool GetBool(string name)
        {
            return (_jsonConfig[name] != null) ? _jsonConfig[name].Value<bool>() : false;
        }
        static public string GetString(string name)
        {
            return (_jsonConfig[name] != null) ? _jsonConfig[name].Value<string>() : "";
        }
        static public int GetInteger(string name)
        {
            return (_jsonConfig[name] != null) ? _jsonConfig[name].Value<int>() : 0;
        }
        static public float GetFloat(string name)
        {
            return (_jsonConfig[name] != null) ? _jsonConfig[name].Value<float>() : 0.0f;
        }

        /* Set a config variable */
        static public void SetBool(string name, bool value)
        {
            _jsonConfig[name] = value;
            Save();
        }
        static public void SetString(string name, string value)
        {
            _jsonConfig[name] = value;
            Save();
        }
        static public void SetInteger(string name, int value)
        {
            _jsonConfig[name] = value;
            Save();
        }
        static public void SetFloat(string name, float value)
        {
            _jsonConfig[name] = value;
            Save();
        }
        static private void Save()
        {
            File.WriteAllText(_configPath, _jsonConfig.ToString(Formatting.Indented));
        }
    }
}
