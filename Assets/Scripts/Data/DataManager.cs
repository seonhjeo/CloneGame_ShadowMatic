using UnityEngine;

namespace Data
{
    public partial class DataManager
    {
        public static DataManager Instance;
        
        public PlayerData PlayerData { get; private set; }
        public LevelDatas LevelData { get; private set; }

        // Level that player check in UI, not related to stored data
        [HideInInspector]
        public int curLevel = -1;

        public void SavePlayerData() => _SavePlayerData();
        public void SaveLevelData() => _SaveLevelData();
    }
    
    public partial class DataManager
    {
        private readonly JsonConverter _jsonConverter = new JsonConverter();
    }
    
    public partial class DataManager : MonoBehaviour
    {
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);

            _LoadData();
        }
    }

    public partial class DataManager
    {
        private void _LoadData()
        {
            PlayerData = _jsonConverter.LoadEncryptedJsonFile<PlayerData>(Application.dataPath, "DataFile/PlayerData");
            LevelData = _jsonConverter.LoadEncryptedJsonFile<LevelDatas>(Application.dataPath, "DataFile/LevelData");
        }
        
        private void _SavePlayerData()
        {
            string s = _jsonConverter.ObjectToJson(PlayerData);
            _jsonConverter.CreateOrSaveEncryptedJsonFile(Application.dataPath, "DataFile/PlayerData", s);
            
        }

        private void _SaveLevelData()
        {
            string s = _jsonConverter.ObjectToJson(LevelData);
            _jsonConverter.CreateOrSaveEncryptedJsonFile(Application.dataPath, "DataFile/LevelData", s);
        }
    }
}


