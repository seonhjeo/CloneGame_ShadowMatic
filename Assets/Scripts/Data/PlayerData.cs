using System;
using System.Collections.Generic;

namespace Data
{
    public class ProgressTimeData
    {
        public int LevelID;
        public float ProgressTime;

        public ProgressTimeData()
        {
            LevelID = 0;
            ProgressTime = -1f;
        }

        public ProgressTimeData(int levelID, float progressTime)
        {
            LevelID = levelID;
            ProgressTime = progressTime;
        }
    }
    
    [Serializable]
    public class PlayerData
    {
        // Game Data
        public int ProgressLevel;
        public List<ProgressTimeData> ProgressTime = new List<ProgressTimeData>();

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


