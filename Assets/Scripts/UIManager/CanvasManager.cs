
using System.Collections;
using UnityEngine;

using ScriptableObj;
using UIManager.Base_Script;

namespace UIManager
{
    public partial class CanvasManager // Properties and Methods that other classes can use
    {
        [field:SerializeField]
        public FadeUiSo UiData { get; private set; }
        
        public bool Status { get; private set; }
        
        public void SetStatus(bool status) => _SetStatus(status);

        public void FadeIn() => _FadeCanvas(UiData.canvasDelay, true);
        
        public void FadeOut() => _FadeCanvas(UiData.canvasDelay, false);
    }
    
    public partial class CanvasManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        private bool _fadeStatus = true;
    }
    
    public partial class CanvasManager : MonoBehaviour
    {

        private void Start()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            _fadeStatus = false;
            FadeIn();
        }
    }

    public partial class CanvasManager : IUIManager, IFade
    {
        private void _SetStatus(bool status)
        {
            Status = status;
            gameObject.SetActive(status);
        }

        private void _FadeCanvas(float time, bool isIn)
        {
            if (isIn != _fadeStatus)
            {
                StartCoroutine(DoFade(time, isIn));
            }
        }

        /// <summary>
        /// foad in or out the canvas
        /// </summary>
        /// <param name="time">fade time, in seconds</param>
        /// <param name="isIn">if it's true, it's fade in. else, it's fade out</param>
        private IEnumerator DoFade(float time, bool isIn)
        {
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

