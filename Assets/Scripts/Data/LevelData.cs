using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public struct LevelData
    {
        public int LevelID;
        public string LevelName;
        public string LevelImagePath;
        public string LevelObjPath;

        public void SetData()
        {
            LevelID = 0;
            LevelName = "-";
            LevelImagePath = "-";
            LevelObjPath = "-";
        }
        
        public void SetData(LevelData data)
        {
            LevelID = data.LevelID;
            LevelName = data.LevelName;
            LevelImagePath = data.LevelImagePath;
            LevelObjPath = data.LevelObjPath;
        }
    }
}


