
using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BlurUIData", menuName = "Scriptable Object/Blur UI Data")]
    public class BlurUiSo : ScriptableObject
    {
        public float blurIntensity = 1.2f;
    }
}


