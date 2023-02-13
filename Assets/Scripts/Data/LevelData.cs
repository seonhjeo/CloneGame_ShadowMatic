
using System;
using System.Collections.Generic;

namespace Data
{
    [Serializable]
    public class LevelData
    {
        public int LevelID;
        public string LevelName;
        public string LevelImagePath;
        public string LevelObjPath;

        public LevelData()
        {
            LevelID = 0;
            LevelName = "-";
            LevelImagePath = "-";
            LevelObjPath = "-";
        }
        
        public LevelData(LevelData data)
        {
            LevelID = data.LevelID;
            LevelName = data.LevelName;
            LevelImagePath = data.LevelImagePath;
            LevelObjPath = data.LevelObjPath;
        }
    }
    
    public class LevelDatas
    {
        public List<LevelData> Datas = new List<LevelData>();

        public LevelDatas()
        {
            LevelData temp = new LevelData();
            Datas.Add(temp);
            Datas.Add(temp);
            Datas.Add(temp);
        }

        public LevelData[] ToArray()
        {
            return Datas.ToArray();
        }
    }
}


