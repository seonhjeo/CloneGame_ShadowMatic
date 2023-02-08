
using System;
using System.Collections;
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UIManager.Base_Script;
using ScriptableObj;
using UnityEngine.SceneManagement;

namespace UIManager
{
    public partial class IndicatorManager // Properties and Methods that other classes can use
    {
        [field:SerializeField]
        public FadeUiSo UiData { get; private set; }

        public void SetResult(float rtime, float ltime) => _SetResult(rtime, ltime);

        public void SetProgressValue(float progress) => _SetProgressValue(progress);

        public void LoadMenuScene() => _LoadMenuScene();
    }
    
    public partial class IndicatorManager // Properties and Methods that only this class use
    {
        [SerializeField] private Slider slider;
        [SerializeField] private TMP_Text text;
    }
    
    public partial class IndicatorManager : MonoBehaviour
    {
        private void Awake()
        {
            text.alpha = 0f;
        }
    }
    
    public partial class IndicatorManager : IUIManager
    {
        private void _SetProgressValue(float progress)
        {
            slider.value = progress;
        }
        
        private void _SetResult(float rtime, float ltime)
        {
            text.text = Math.Round(rtime, 2).ToString(CultureInfo.CurrentCulture);
            StartCoroutine(_CorFadeTextIn(ltime));
        }

        private void _LoadMenuScene()
        {
            // TODO : load Game
            StartCoroutine(_LoadMenuSceneCor());
        }

        private IEnumerator _LoadMenuSceneCor()
        {
            yield return new WaitForSeconds(UiData.canvasDelay * 2);

            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("MenuScene");

            while (!asyncOperation.isDone)
            {
                yield return null;
            }
        }

        private IEnumerator _CorFadeTextIn(float time)
        {
            float tempTime = 0f;

            while (tempTime < time)
            {
                text.alpha = Mathf.Lerp(0f, 1f, tempTime / time);
                tempTime += Time.deltaTime;
                yield return null;
            }
        }
    }
}

