using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ML.SavingSystem
{
    public class WeaponStats : MonoBehaviour, ISavable
    {
        [SerializeField] private bool weaponUnlocked = false;
        [SerializeField] private string weaponName = "";
        [SerializeField] private int weaponSerialNumber = 0;

        public void Save(GameData gameData)
        {
            gameData.AddGameData(nameof(weaponUnlocked), weaponUnlocked, dataType.Boolean);
            gameData.AddGameData(nameof(weaponName), weaponName, dataType.String);
            gameData.AddGameData(nameof(weaponSerialNumber), weaponSerialNumber, dataType.Integer);
        }

        public void Load(GameData gameData)
        {
            if (gameData.GetValue(dataType.Boolean, nameof(weaponUnlocked)) != null)
            {
                weaponUnlocked = (bool)gameData.GetValue(dataType.Boolean, nameof(weaponUnlocked));
            }

            if (gameData.GetValue(dataType.String, nameof(weaponName)) != null)
            {
                weaponName = (string)gameData.GetValue(dataType.String, nameof(weaponName));
            }

            if (gameData.GetValue(dataType.Integer, nameof(weaponSerialNumber)) != null)
            {
                weaponSerialNumber = (int)gameData.GetValue(dataType.Integer, nameof(weaponSerialNumber));
            }

        }

    }

}