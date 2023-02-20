using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    /// <summary>
    /// This class is for modifying data by developer
    /// Create empty Class, add this script, edit this script and push play button to save data;
    /// </summary>
    public partial class FileManager
    {
        
    }
    
    public partial class FileManager
    {
        private JsonConverter _jsonConverter = new JsonConverter();
    }
    
    public partial class FileManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            LevelDatas lData = _InjectLevelData();
            _jsonConverter.CreateOrSaveEncryptedJsonFile(Application.dataPath, "DataFile/LevelData", _jsonConverter.ObjectToJson(lData));

            PlayerData pData = _InjectPlayerData();
            _jsonConverter.CreateOrSaveEncryptedJsonFile(Application.dataPath, "DataFile/PlayerData", _jsonConverter.ObjectToJson(pData));

        }

        private LevelDatas _InjectLevelData()
        {
            LevelDatas lData = new LevelDatas();
            
            LevelData temp = new LevelData();
            temp.levelName = "teapot";
            temp.levelID = 0;
            temp.levelImagePath = "Object Sprite/teapot";
            temp.levelObjPath = "Prefabs/Rotating Objects/tea_pot";
            lData.Datas.Add(temp);

            LevelData temp2 = new LevelData();
            temp2.levelName = "elephant";
            temp2.levelID = 1;
            temp2.levelImagePath = "Object Sprite/elephant";
            temp2.levelObjPath = "Prefabs/Rotating Objects/elephant";
            lData.Datas.Add(temp2);

            LevelData temp3 = new LevelData();
            temp3.levelName = "42 Logo";
            temp3.levelID = 2;
            temp3.levelImagePath = "Object Sprite/42-Logo";
            temp3.levelObjPath = "Prefabs/Rotating Objects/Revoluter 42";
            lData.Datas.Add(temp3);

            // LevelData temp4 = new LevelData();
            // temp4.levelName = "Globe";
            // temp4.levelID = 3;
            // temp4.levelImagePath = "Object Sprite/globe";
            // temp4.levelObjPath = "Prefabs/Rotating Objects/Revoluter Globe";
            // lData.Datas.Add(temp4);

            return lData;
        }

        private PlayerData _InjectPlayerData()
        {
            PlayerData pData = new PlayerData();

            pData.ProgressLevel = 0;
            pData.ProgressTime = new List<ProgressTimeData>();
            pData.ProgressTime.Add(new ProgressTimeData());

            return pData;
        }
    }
}