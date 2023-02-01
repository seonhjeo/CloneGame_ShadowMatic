
using System.Collections;
using UnityEngine;

using ScriptableObj;
using UIManager.Base_Script;

namespace UIManager
{
    public partial class CanvasManager // Properties and Methods that other classes can use
    {
        [field:SerializeField]
        public FadeUiSo FadeUiData { get; private set; }
        
        public void FadeIn() => _FadeCanvas(FadeUiData.canvasDelay, true);
        
        public void FadeOut() => _FadeCanvas(FadeUiData.canvasDelay, false);

        public void StartToMain() => _StartToMain();
    }
    
    public partial class CanvasManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        [SerializeField] private GameObject startPanel;
        [SerializeField] private GameObject mainPanel;

        private bool _fadeStatus = true;
    }
    
    public partial class CanvasManager : MonoBehaviour
    {
    }

    public partial class CanvasManager : IUIManager, IFade
    {

        private void _StartToMain()
        {
            StartCoroutine(DoFade(FadeUiData.canvasDelay, false));
            StartCoroutine(_SwitchPanel(startPanel, mainPanel));
            StartCoroutine(DoFade(FadeUiData.canvasDelay, true, FadeUiData.canvasDelay * 2));
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
            float cur = canvasGroup.alpha;

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

