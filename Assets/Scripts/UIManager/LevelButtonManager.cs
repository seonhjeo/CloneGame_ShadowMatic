
using System.Collections;
using UnityEngine;

using Data;
using ScriptableObj;
using UIManager.Base_Script;
using UnityEngine.SceneManagement;

namespace UIManager
{
    public partial class LevelButtonManager // Properties and Methods that other classes can use
    {
        public LevelData Data;

        public void InitData(LevelData data) => _InitData(data);

        public void LoadGame() => _LoadGame();
    }
    
    public partial class LevelButtonManager // Properties and Methods that only this class use
    {
        [SerializeField] private FadeUiSo fadeData;
    }
    
    public partial class LevelButtonManager : MonoBehaviour, IUIManager
    {
        private void _InitData(LevelData data)
        {
            Data = data;
        }

        private void _LoadGame()
        {
            // TODO : load Game by Data
            DataManager.Instance.curLevel = Data.LevelID;
            StartCoroutine(_LoadGameScene());
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


