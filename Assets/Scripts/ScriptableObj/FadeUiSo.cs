
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "FadeUIData", menuName = "Scriptable Object/Fade UI Data")]
    public class FadeUiSo : ScriptableObject
    {
        public float canvasDelay = 1.0f;
        public float sceneDelay = 1.5f;
    }
}


