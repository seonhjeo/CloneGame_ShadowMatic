

using UnityEngine;
using UnityEngine.EventSystems;

namespace UIManager
{
    public partial class EventSystemManager // Properties and Methods that other classes can use
    {
        public bool Status { get; private set; } = true;

        public void SetStatus(bool status) => _SetStatus(status);
    }
    
    public partial class EventSystemManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private EventSystem eventSystem;
    }
    
    public partial class EventSystemManager : MonoBehaviour
    {
        
    }
    
    public partial class EventSystemManager : IUIManager
    {
        private void _SetStatus(bool status)
        {
            Status = status;
            eventSystem.enabled = status;
        }
    }
}


