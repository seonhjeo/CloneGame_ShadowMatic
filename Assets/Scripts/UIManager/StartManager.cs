
using UnityEngine;

using ScriptableObj;
using UIManager.Base_Script;

namespace UIManager
{
    public partial class StartManager // Properties and Methods that other classes can use
    {
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
        private void _GoToMainMenu()
        {
            
        }
        
        private void _QuitGame()
        {
            // TODO : change at build
            UnityEditor.EditorApplication.isPlaying = false;
            // Application.Quit();
        }
    }
}

