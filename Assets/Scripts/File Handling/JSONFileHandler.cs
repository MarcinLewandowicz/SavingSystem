using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ML.SavingSystem
{
    public class JSONFileHandler : FileHandler
    {
        private readonly string encryptionCodeWord = "secret";
        private CloudSave cloudSave;

        public JSONFileHandler(string fileName, string filePath, bool useEncryption, bool useCloudSaveLoadSystem)
        {
            this.fileName = fileName;
            this.filePath = filePath;
            this.useEncryption = useEncryption;
            this.useCloudSaveLoadSystem = useCloudSaveLoadSystem;
            cloudSave = new CloudSave();
        }

        public override GameData LoadGameData()
        {
            string fullFilePath = Path.Combine(filePath, fileName);
            GameData loadedData = new GameData();

            if (useCloudSaveLoadSystem)
            {
                cloudSave.LoadFileFromCloud(fileName, fullFilePath);
            }
            if (File.Exists(fullFilePath))
            {
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullFilePath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            Debug.Log("Data loaded from file.");
            return loadedData;
        }

        public override void SaveGameData(GameData data, bool useEncryption)
        {
            string fileFullPath = Path.Combine(filePath, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(fileFullPath));
            string dataToSave = JsonUtility.ToJson(data, true);

            if (useEncryption)
            {
                dataToSave = EncryptDecrypt(dataToSave);
            }

            using (FileStream stream = new FileStream(fileFullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
            Debug.Log("Data saved to file.");
            if (useCloudSaveLoadSystem)
            {
                cloudSave.SaveFileToCloud(fileName, fileFullPath);
            }
        }

        private string EncryptDecrypt(string data)
        {
            string modifiedData = "";

            for (int i = 0; i < data.Length; i++)
            {
                modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
            }
            return modifiedData;
        }
    }

}