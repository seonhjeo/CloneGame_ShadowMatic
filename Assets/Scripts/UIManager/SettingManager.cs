
using System.Collections;
using Data;
using UnityEngine;
using UnityEngine.UI;

using ScriptableObj;
using UIManager.Base_Script;

namespace UIManager
{
    public partial class SettingManager // Properties and Methods that other classes can use
    {
        [field: SerializeField] public FadeUiSo FadeUiData { get; private set; }
        [field: SerializeField] public BlurUiSo BlurUiData { get; private set; }

        public void FadeIn() => _FadeCanvas(FadeUiData.canvasDelay, true);

        public void FadeOut() => _FadeCanvas(FadeUiData.canvasDelay, false);

        public void SaveSetting() => _SaveSetting();
    }

    public partial class SettingManager // Properties and Methods that only this class use
    {
        [SerializeField] private Image image;

        [SerializeField] private CanvasGroup canvasGroup;

        [SerializeField] private FSPManager mouseSensitivity;
        [SerializeField] private FSPManager bgmVolume;

        private bool _fadeStatus;

        private Material _material;
        private int _alphaId;
    }

    public partial class SettingManager : MonoBehaviour
    {
        private void Awake()
        {
            _fadeStatus = false;
            _material = image.material;
            _alphaId = Shader.PropertyToID("_Size");
        }

        private void OnEnable()
        {
            _InitSetting();
        }
    }

    public partial class SettingManager : IUIManager, IBlur
    {
        private void _InitSetting()
        {
            if (mouseSensitivity)
                mouseSensitivity.SetValue(DataManager.Instance.PlayerData.MouseSensitivity);
            if (bgmVolume)
                bgmVolume.SetValue(DataManager.Instance.PlayerData.BGMVolume);
        }
        
        private void _SaveSetting()
        {
            DataManager.Instance.PlayerData.MouseSensitivity = mouseSensitivity.GetValue();
            DataManager.Instance.PlayerData.BGMVolume = bgmVolume.GetValue();
            DataManager.Instance.SavePlayerData();
        }
        
        private void _FadeCanvas(float time, bool isIn)
        {
            if (isIn != _fadeStatus)
            {
                StartCoroutine(DoFade(time, isIn));
            }
        }

        /// <summary>
        /// fade in or out the canvas
        /// </summary>
        /// <param name="time">fade time, in seconds</param>
        /// <param name="isIn">if it's true, it's fade in. else, it's fade out</param>
        private IEnumerator DoFade(float time, bool isIn)
        {
            float tempTime = 0f;
            float final = isIn ? 1f : 0f;
            float start = isIn ? 0f : 1f;

            if (!isIn)
            {
                canvasGroup.interactable = false;
                _fadeStatus = false;
            }
            else
            {
                canvasGroup.blocksRaycasts = true;
            }

            while (tempTime < time)
            {
                float temp = Mathf.Lerp(start, final, tempTime / time);
                canvasGroup.alpha = temp;
                _material.SetFloat(_alphaId, temp * BlurUiData.blurIntensity);
                tempTime += Time.deltaTime;
                yield return null;
            }

            canvasGroup.alpha = final;
            _material.SetFloat(_alphaId, final * BlurUiData.blurIntensity);

            if (isIn)
            {
                canvasGroup.interactable = true;
                _fadeStatus = true;
            }
            else
            {
                canvasGroup.blocksRaycasts = false;
            }

            yield return null;
        }
    }
}

