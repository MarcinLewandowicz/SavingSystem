using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ML.SavingSystem
{
    public abstract class FileHandler
    {
        public abstract void SaveGameData(GameData data, bool useEncryption);
        public abstract GameData LoadGameData();

        protected string fileName = "";
        protected string filePath = "";
        protected bool useEncryption = false;
        protected bool useCloudSaveLoadSystem = false;
    }


}