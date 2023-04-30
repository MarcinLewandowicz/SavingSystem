using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ML.SavingSystem
{
    public class PlayerStats : MonoBehaviour, ISavable
    {

        [SerializeField] private int playerHealthPoints = 5;
        [SerializeField] private float playerMovevmentSpeed = 10f;
        [SerializeField] private Vector3 playerPosition;

        private void Update()
        {
            playerPosition = transform.position;
        }
        public void Save(GameData gameData)
        {
            gameData.AddGameData(nameof(playerHealthPoints), playerHealthPoints, dataType.Integer);
            gameData.AddGameData(nameof(playerMovevmentSpeed), 123.23f, dataType.Float);

            gameData.AddGameData(nameof(playerPosition)+"x", playerPosition.x, dataType.Float);
            gameData.AddGameData(nameof(playerPosition)+"y", playerPosition.y, dataType.Float);
            gameData.AddGameData(nameof(playerPosition)+"z", playerPosition.z, dataType.Float);
        }

        public void Load(GameData gameData)
        {
            if (gameData.GetValue(dataType.Integer, nameof(playerHealthPoints)) != null)
            playerHealthPoints = (int)gameData.GetValue(dataType.Integer, nameof(playerHealthPoints));
            

            if (gameData.GetValue(dataType.Float, nameof(playerMovevmentSpeed)) != null)
            playerMovevmentSpeed = (float)gameData.GetValue(dataType.Float, nameof(playerMovevmentSpeed));
            

            if (gameData.GetValue(dataType.Float, nameof(playerPosition)+"x") != null)
            {
                transform.position = new Vector3(
                    (float)gameData.GetValue(dataType.Float, nameof(playerPosition) + "x"),
                    (float)gameData.GetValue(dataType.Float, nameof(playerPosition) + "y"),
                    (float)gameData.GetValue(dataType.Float, nameof(playerPosition) + "z"));
            }

        }
    }

}