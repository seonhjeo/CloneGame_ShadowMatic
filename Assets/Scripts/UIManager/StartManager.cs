
using ScriptableObj;
using UnityEngine;


namespace UIManager
{
    public partial class StartManager // Properties and Methods that other classes can use
    {
        public bool Status { get; private set; } = true;

        public void SetStatus(bool status) => _SetStatus(status);

        public void QuitGame() => _QuitGame();
    }

    public partial class StartManager // Properties and Methods that only this class use
    {
        
    }
    
    public partial class StartManager : MonoBehaviour
    {

    }

    public partial class StartManager : IUIManager
    {
        private void _SetStatus(bool status)
        {
            Status = status;
            gameObject.SetActive(status);
        }

        
        
        private void _QuitGame()
        {
            // TODO : change at build
            UnityEditor.EditorApplication.isPlaying = false;
            // Application.Quit();
        }
    }
}
