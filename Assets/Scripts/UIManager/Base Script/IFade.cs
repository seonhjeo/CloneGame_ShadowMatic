
using ScriptableObj;

namespace UIManager.Base_Script
{
    public interface IFade
    {
        FadeUiSo UiData { get; }
        
        /// <summary> Fade In </summary>
        void FadeIn();
        
        /// <summary> Fade Out </summary>
        void FadeOut();
    }
}


