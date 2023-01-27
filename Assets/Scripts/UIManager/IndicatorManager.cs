
using System.Globalization;

using UnityEngine;
using UnityEngine.UI;

using TMPro;
using UIManager.Base_Script;
using ScriptableObj;

namespace UIManager
{
    public partial class IndicatorManager // Properties and Methods that other classes can use
    {
        [field:SerializeField]
        public FadeUiSo UiData { get; private set; }
        public bool Status { get; private set; }
        
        public void SetStatus(bool status) => _SetStatus(status);

        public void SetTimeValue(float time) => _SetTimeValue(time);

        public void SetProgressValue(float progress) => _SetProgressValue(progress);
        
        public void FadeIn() => _FadeIn();
        
        public void FadeOut() => _FadeOut();
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
            text.gameObject.SetActive(false);
        }
    }
    
    public partial class IndicatorManager : IUIManager
    {
        private void _SetStatus(bool status)
        {
            Status = status;
            gameObject.SetActive(status);
        }

        private void _SetProgressValue(float progress)
        {
            slider.value = progress;
        }
        
        private void _SetTimeValue(float time)
        {
            text.gameObject.SetActive(true);
            text.text = time.ToString(CultureInfo.CurrentCulture);
        }

        private void _FadeIn()
        {
            
        }
        
        private void _FadeOut()
        {
            
        }
    }
}

