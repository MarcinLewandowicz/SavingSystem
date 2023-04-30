using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ML.SavingSystem
{
    [System.Serializable]
    public class GameData
    {
        public bool cleanGameData = true;
        public SerializableDictionary<string, int> gameDataIntegers;
        public SerializableDictionary<string, float> gameDataFloats;
        public SerializableDictionary<string, string> gameDataStrings;
        public SerializableDictionary<string, bool> gameDataBooleans;

        public object GetValue(dataType dataType, string key)
        {
            switch (dataType)
            {
                case dataType.Integer:
                    if (gameDataIntegers.ContainsKey(key))
                    {
                        return gameDataIntegers[key];
                    }
                    else
                    {
                        return null;
                    }
                case dataType.Boolean:
                    if (gameDataBooleans.ContainsKey(key))
                    {
                        return gameDataBooleans[key];
                    }
                    else
                    {
                        return null;
                    }
                case dataType.Float:
                    if (gameDataFloats.ContainsKey(key))
                    {
                        return gameDataFloats[key];
                    }
                    else
                    {
                        return null;
                    }
                case dataType.String:
                    if (gameDataStrings.ContainsKey(key))
                    {
                        return gameDataStrings[key];
                    }
                    else
                    {
                        return null;
                    }
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
                        gameDataIntegers[key] = (int)value;
                        break;
                    case dataType.Boolean:
                        gameDataBooleans[key] = (bool)value;
                        break;
                    case dataType.Float:
                        gameDataFloats[key] = (float)value;
                        break;
                    case dataType.String:
                        gameDataStrings[key] = (string)value;
                        break;
                }
            }
            else
            {
                switch (dataType)
                {
                    case dataType.Integer:
                        gameDataIntegers.Add(key, (int)value);
                        break;
                    case dataType.Boolean:
                        gameDataBooleans.Add(key, (bool)value);
                        break;
                    case dataType.Float:
                        gameDataFloats.Add(key, (float)value);
                        break;
                    case dataType.String:
                        gameDataStrings.Add(key, (string)value);
                        break;
                }
            }
        }

        private bool KeyAlreadyExist(string key)
        {
            return (gameDataBooleans.ContainsKey(key) ||
                    gameDataFloats.ContainsKey(key) ||
                    gameDataIntegers.ContainsKey(key) ||
                    gameDataStrings.ContainsKey(key));
        }
    }

    public enum dataType
    {
        Integer, Float, String, Boolean
    }

}