
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "UIData", menuName = "Scriptable Object/UI Data")]
    public class FadeUiSo : ScriptableObject
    {
        public float canvasDelay = 1.5f;
        public float sceneDelay = 1.5f;
    }
}


