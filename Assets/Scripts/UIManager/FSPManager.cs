using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UIManager.Base_Script;

namespace UIManager
{
    public partial class FSPManager
    {
        public void SetSlider() => _SetSlider();

        public void SetInputField() => _SetInputField();

        public void SetValue(float value) => _SetValue(value);

        public float GetValue() => _GetValue();
    }
    
    public partial class FSPManager
    {
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Slider slider;
        
        private float _curValue;
    }
    
    
    public partial class FSPManager : MonoBehaviour, IUIManager
    {
        
        private void _SetSlider()
        {
            try
            {
                _curValue = (float)Math.Round(double.Parse(inputField.text, CultureInfo.InvariantCulture), 3);
            }
            catch(FormatException e)
            {
                Debug.Log(e);
            }
            
            if (_curValue < slider.minValue)
            {
                _curValue = slider.minValue;
                inputField.text = _curValue.ToString(CultureInfo.InvariantCulture);
            }

            if (_curValue > slider.maxValue)
            {
                _curValue = slider.maxValue;
                inputField.text = _curValue.ToString(CultureInfo.InvariantCulture);
            }
            slider.value = _curValue;
        }

        private void _SetInputField()
        {
            inputField.text = (slider.value).ToString(CultureInfo.InvariantCulture);
        }

        private void _SetValue(float value)
        {
            _curValue = value;
            _SetSlider();
            _SetInputField();
        }

        private float _GetValue()
        {
            return _curValue;
        }
    }
}


