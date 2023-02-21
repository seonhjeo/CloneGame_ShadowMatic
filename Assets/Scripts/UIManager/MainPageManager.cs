using Data;
using UnityEngine;

namespace UIManager
{
    public partial class MainPageManager
    {
        
    }
    
    public partial class MainPageManager
    {
        [SerializeField] private GameObject levelButton;
        [SerializeField] private Transform scrollViewContent;
        [SerializeField] private GameObject testModeText;
    }
    
    public partial class MainPageManager : MonoBehaviour
    {
        private void OnEnable()
        {
            if (DataManager.Instance.isTest)
            {
                testModeText.SetActive(true);
            }
            else
            {
                testModeText.SetActive(false);
            }
            
            if (scrollViewContent.transform.childCount != 0)
            {
                foreach (Transform child in scrollViewContent.transform)
                {
                    Destroy(child.gameObject);
                }
            }

            LevelDatas lData = DataManager.Instance.LevelData;
            PlayerData pData = DataManager.Instance.PlayerData;

            for (int i = 0; i < lData.Datas.Count; i++)
            {
                GameObject button = Instantiate(levelButton, scrollViewContent);
                LevelButtonManager manager = button.GetComponent<LevelButtonManager>();

                if (DataManager.Instance.isTest)
                {
                    manager.InitData(lData.Datas[i], pData.ProgressTime[i]);
                }
                else
                {
                    if (i < pData.ProgressLevel)
                    {
                        manager.InitData(lData.Datas[i], pData.ProgressTime[i]);
                    }
                    else if (i == pData.ProgressLevel)
                    {
                        LevelData temp = new LevelData(lData.UnKnownLevel);
                        temp.levelID = i;
                    
                        manager.InitData(temp, 0f);
                    }
                    else
                    {
                        manager.InitData(lData.UnKnownLevel, 0.0f);
                    }
                }
                
            }
        }
    }
}


