using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ML.SavingSystem
{
    public interface ISavable
    {
        void Save(GameData gameData);
        void Load(GameData gameData);
    }


}