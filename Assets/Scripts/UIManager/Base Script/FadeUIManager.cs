
using UnityEngine;

using ScriptableObj;


namespace UIManager
{
    public abstract partial class FadeUIManager
    {
        public bool Status { get; protected set; } = true;
        
        public abstract void SetStatus(bool status);

        public abstract void FadeIn();
        
        public abstract void FadeOut();
    }
    public abstract partial class FadeUIManager
    {
        [SerializeField] private UISo uiData;
    }
    
    public abstract partial class FadeUIManager : MonoBehaviour
    {
    }
    
    public abstract partial class FadeUIManager : IFade, IUIManager
    {
    }
}


