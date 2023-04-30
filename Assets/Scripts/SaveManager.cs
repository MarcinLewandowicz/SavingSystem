using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ML.SavingSystem
{

    public class SaveManager : MonoBehaviour
    {
        public static SaveManager instance { get; private set; }

        [SerializeField] private FileHandlerType fileType;
        [SerializeField] private string fileName = "";
        [SerializeField] private bool useEncryption = false;
        [SerializeField] private bool useCloudSaveLoadSystem = false;
        [SerializeField] private GameData gameData;
        private FileHandler fileHandler;
        private List<ISavable> savableOjbects;


        private void Awake()
        {
            if (instance == null)
            instance = this;            
            else
            Destroy(gameObject);            
        }

        private void Start()
        {
            fileHandler = new FileHandlerFactory().GetFileHandler(fileType, fileName, Application.persistentDataPath, useEncryption, useCloudSaveLoadSystem);
            savableOjbects = FindAllSavableObjects();
            LoadGameState();
        }

        private void LoadGameState()
        {
            gameData = fileHandler.LoadGameData();
            if (IsGameDataEmpty())
            {
                Debug.Log("Empty game data file - initializing new game data");
                InitializeNewGameData();
            }
            else
            {
                Debug.Log("Game data available - loading state from file");
                foreach (ISavable savable in savableOjbects)
                savable.Load(gameData);                
            }
        }

        private bool IsGameDataEmpty()
        {
            return gameData.cleanGameData;
        }

        private void InitializeNewGameData()
        {
            gameData = new GameData();
            gameData.cleanGameData = false;
        }

        private List<ISavable> FindAllSavableObjects()
        {
            IEnumerable<ISavable> savableList = FindObjectsOfType<MonoBehaviour>().OfType<ISavable>();
            return new List<ISavable>(savableList);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            SaveDataToFile();
            
            if (Input.GetKeyDown(KeyCode.L))
            LoadDataFromFile();            
        }

        private void LoadDataFromFile()
        {
            foreach (ISavable savable in savableOjbects)
            savable.Load(gameData);            
        }

        private void SaveDataToFile()
        {
            foreach (ISavable savable in savableOjbects)
            savable.Save(gameData);            

            fileHandler.SaveGameData(gameData, useEncryption);
        }
    }
}