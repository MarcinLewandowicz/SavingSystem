using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ML.SavingSystem
{
    [System.Serializable]
    public class GameData
    {
        public bool cleanGameData = true;
        public SerializableDictionary<string, int> GameDataIntegers;
        public SerializableDictionary<string, float> GameDataFloats;
        public SerializableDictionary<string, string> GameDataStrings;
        public SerializableDictionary<string, bool> GameDataBooleans;

        public object GetValue(dataType dataType, string key)
        {            
            switch (dataType)
            {
                case dataType.Integer:
                    return GameDataIntegers.TryGetValue(key, out int intValue) ? intValue : null;
                case dataType.Boolean:
                    return GameDataBooleans.TryGetValue(key, out bool boolValue) ? boolValue : null;
                case dataType.Float:
                    return GameDataFloats.TryGetValue(key, out float floatValue) ? floatValue : null;
                case dataType.String:
                    return GameDataStrings.TryGetValue(key, out string stringValue) ? stringValue : null;
                default:
                    return null;
            }
        }


        public void AddGameData(string key, object value, dataType dataType)
        {
            if (KeyAlreadyExist(key))
            {
                switch (dataType)
                {
                    case dataType.Integer:
                        GameDataIntegers[key] = (int)value;
                        break;
                    case dataType.Boolean:
                        GameDataBooleans[key] = (bool)value;
                        break;
                    case dataType.Float:
                        GameDataFloats[key] = (float)value;
                        break;
                    case dataType.String:
                        GameDataStrings[key] = (string)value;
                        break;
                }
            }
            else
            {
                switch (dataType)
                {
                    case dataType.Integer:
                        GameDataIntegers.Add(key, (int)value);
                        break;
                    case dataType.Boolean:
                        GameDataBooleans.Add(key, (bool)value);
                        break;
                    case dataType.Float:
                        GameDataFloats.Add(key, (float)value);
                        break;
                    case dataType.String:
                        GameDataStrings.Add(key, (string)value);
                        break;
                }
            }
        }

        private bool KeyAlreadyExist(string key)
        {
            return (GameDataBooleans.ContainsKey(key) ||
                    GameDataFloats.ContainsKey(key) ||
                    GameDataIntegers.ContainsKey(key) ||
                    GameDataStrings.ContainsKey(key));
        }
    }

    public enum dataType
    {
        Integer, Float, String, Boolean
    }

}