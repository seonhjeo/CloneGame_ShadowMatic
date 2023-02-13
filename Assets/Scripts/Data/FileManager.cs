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
            LevelDatas lData = new LevelDatas();
            _jsonConverter.CreateOrSaveJsonFile(Application.dataPath, "DataFile/LevelData", _jsonConverter.ObjectToJson(lData));

            PlayerData pData = new PlayerData();
            _jsonConverter.CreateOrSaveJsonFile(Application.dataPath, "DataFile/PlayerData", _jsonConverter.ObjectToJson(pData));
        }
    }
}