
using ScriptableObj;

namespace UIManager.Base_Script
{
    public interface IFade
    {
        FadeUiSo FadeUiData { get; }
        
        /// <summary> Fade In </summary>
        void FadeIn();
        
        /// <summary> Fade Out </summary>
        void FadeOut();
    }
}


