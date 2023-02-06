
using System.Collections;
using UnityEngine;

using Data;
using UIManager.Base_Script;
using UnityEngine.SceneManagement;

namespace UIManager
{
    public partial class LevelButtonManager // Properties and Methods that other classes can use
    {
        public LevelData Data;
        public LoadLevelSo loadLevelData;

        public void InitData(LevelData data) => _InitData(data);

        public void LoadGame() => _LoadGame();
    }
    
    public partial class LevelButtonManager // Properties and Methods that only this class use
    {
        
    }
    
    public partial class LevelButtonManager : MonoBehaviour, IUIManager
    {
        private void _InitData(LevelData data)
        {
            Data = data;
        }

        private void _LoadGame()
        {
            // TODO : load Game
            loadLevelData.levelToLoad = 0;
            StartCoroutine(_LoadGameScene());
        }

        private IEnumerator _LoadGameScene()
        {
            yield return null;

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("GameScene");

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }
    }
}


