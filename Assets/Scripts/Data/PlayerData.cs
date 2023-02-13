using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class PlayerData
    {
        // Game Data
        public int ProgressLevel;
        public List<float> ProgressTime = new List<float>();

        // Setting Data
        public float MouseSensitivity;
        public float BGMVolume;

        public PlayerData()
        {
            ProgressLevel = 0;
            MouseSensitivity = 1f;
            BGMVolume = 1f;
        }

        public PlayerData(PlayerData data)
        {
            ProgressLevel = data.ProgressLevel;
            ProgressTime = data.ProgressTime;
            MouseSensitivity = data.MouseSensitivity;
            BGMVolume = data.BGMVolume;
        }
    }
}


