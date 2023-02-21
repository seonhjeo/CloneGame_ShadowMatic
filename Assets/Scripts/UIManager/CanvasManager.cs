
using System.Collections;
using Data;
using UnityEngine;

using ScriptableObj;
using UIManager.Base_Script;
using UnityEngine.UI;

namespace UIManager
{
    public partial class CanvasManager // Properties and Methods that other classes can use
    {
        [field:SerializeField]
        public FadeUiSo FadeUiData { get; private set; }
        
        public void FadeIn() => _FadeCanvas(FadeUiData.canvasDelay, true);
        
        public void FadeOut() => _FadeCanvas(FadeUiData.canvasDelay, false);
        
        public void SceneFadeIn() => _FadeCanvas(FadeUiData.sceneDelay, true);
        
        public void SceneFadeOut() => _FadeCanvas(FadeUiData.sceneDelay, false);

        public void QuitGame() => _QuitGame();

        public void ChangeTestMode() => _ChangeTestMode();
        
        public void StartToMain() => _StartToMain();

        public void MainToStart() => _MainToStart();
    }
    
    public partial class CanvasManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject mainPanel;
        [SerializeField] private Toggle testModeToggle;

        private bool _fadeStatus = true;
    }
    
    public partial class CanvasManager : MonoBehaviour
    {
        private void Start()
        {
            testModeToggle.isOn = DataManager.Instance.isTest;
            
            if (DataManager.Instance.curLevel != -1)
            {
                startPanel.SetActive(false);
                mainPanel.SetActive(true);
            }
            StartCoroutine(DoFade(FadeUiData.sceneDelay, true));
        }
    }

    public partial class CanvasManager : IUIManager, IFade
    {

        private void _QuitGame()
        {
            // TODO : change at build
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

        private void _ChangeTestMode()
        {
            DataManager.Instance.isTest = testModeToggle.isOn;
        }
        
        private void _StartToMain()
        {
            if (startPanel && mainPanel)
            {
                StartCoroutine(DoFade(FadeUiData.canvasDelay, false));
                StartCoroutine(_SwitchPanel(startPanel, mainPanel));
                StartCoroutine(DoFade(FadeUiData.canvasDelay, true, FadeUiData.canvasDelay * 2));
            }
        }

        private void _MainToStart()
        {
            if (startPanel && mainPanel)
            {
                StartCoroutine(DoFade(FadeUiData.canvasDelay, false));
                StartCoroutine(_SwitchPanel(mainPanel, startPanel));
                StartCoroutine(DoFade(FadeUiData.canvasDelay, true, FadeUiData.canvasDelay * 2));
            }
        }

        private void _FadeCanvas(float time, bool isIn)
        {
            if (isIn != _fadeStatus)
            {
                StartCoroutine(DoFade(time, isIn));
            }
        }
        
        /// <summary>
        /// switch panel from p1 to p2
        /// </summary>
        /// <param name="p1">panel for deactivate</param>
        /// <param name="p2">panel for activate</param>
        private IEnumerator _SwitchPanel(GameObject p1, GameObject p2)
        {
            yield return new WaitForSeconds(FadeUiData.canvasDelay);
 
            p1.SetActive(false);
            p2.SetActive(true);
        }
        
        /// <summary>
        /// fade in or out the canvas
        /// </summary>
        /// <param name="time">fade time, in seconds</param>
        /// <param name="isIn">if it's true, it's fade in. else, it's fade out</param>
        private IEnumerator DoFade(float time, bool isIn, float delay = 0f)
        {
            if (delay != 0f)
            {
                yield return new WaitForSeconds(delay);
            }
            
            float tempTime = 0f;
            float final = isIn ? 1f : 0f;
            float cur = isIn ? 0f : 1f;

            if (!isIn)
            {
                canvasGroup.interactable = false;
                _fadeStatus = false;
            }
            
            while (tempTime < time)
            {
                canvasGroup.alpha = Mathf.Lerp(cur, final, tempTime / time);
                tempTime += Time.deltaTime;
                yield return null;
            }
            canvasGroup.alpha = final;
            
            if (isIn)
            {
                canvasGroup.interactable = true;
                _fadeStatus = true;
            }
            yield return null;
        }
    }
}

