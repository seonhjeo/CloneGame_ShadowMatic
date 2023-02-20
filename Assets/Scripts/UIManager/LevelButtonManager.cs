
using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

using Data;
using ScriptableObj;
using UIManager.Base_Script;


namespace UIManager
{
    public partial class LevelButtonManager // Properties and Methods that other classes can use
    {
        public LevelData Data;

        public void InitData(LevelData data, float time) => _InitData(data, time);

        public void LoadGame() => _LoadGame();
    }
    
    public partial class LevelButtonManager // Properties and Methods that only this class use
    {
        [SerializeField] private FadeUiSo fadeData;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Image image;

        private CanvasManager _manager;
    }
    
    public partial class LevelButtonManager : MonoBehaviour, IUIManager
    {
        private void _InitData(LevelData data, float time)
        {
            Data = data;
            nameText.text = Data.levelName;
            timeText.text = Math.Round(time, 2).ToString(CultureInfo.InvariantCulture);
            Sprite s = Resources.Load<Sprite>(Data.levelImagePath);
            image.sprite = s;
        }

        private void _LoadGame()
        {
            // TODO : load Game by Data
            if (Data.levelID >= 0)
            {
                _manager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
                _manager.SceneFadeOut();
                
                DataManager.Instance.curLevel = Data.levelID;
                StartCoroutine(_LoadGameScene());
            }
        }

        private IEnumerator _LoadGameScene()
        {
            yield return new WaitForSeconds(fadeData.sceneDelay);

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}


