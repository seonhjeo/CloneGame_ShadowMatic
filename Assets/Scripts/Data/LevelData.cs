
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace Data
{
    [Serializable]
    public class LevelData
    {
        public int levelID;
        public string levelName;
        public string levelImagePath;
        public string levelObjPath;

        public LevelData()
        {
            levelID = 0;
            levelName = "-";
            levelImagePath = "-";
            levelObjPath = "-";
        }
        
        public LevelData(LevelData data)
        {
            levelID = data.levelID;
            levelName = data.levelName;
            levelImagePath = data.levelImagePath;
            levelObjPath = data.levelObjPath;
        }
    }
    
    public class LevelDatas
    {
        public LevelData UnKnownLevel;
        
        public List<LevelData> Datas = new List<LevelData>();

        
        // Inject LevelData in here
        public LevelDatas()
        {
            UnKnownLevel = new LevelData();
            UnKnownLevel.levelName = "unknown";
            UnKnownLevel.levelID = -1;
            UnKnownLevel.levelImagePath = "Object Sprite/unknown";
            UnKnownLevel.levelObjPath = null;
        }

        public LevelData[] ToArray()
        {
            return Datas.ToArray();
        }
    }
}


