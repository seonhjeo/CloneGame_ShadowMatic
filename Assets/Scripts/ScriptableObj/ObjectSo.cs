using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "Object Data", menuName = "Scriptable Object/Object Data")]
    public class ObjectSo : ScriptableObject
    {
        public string objectName;
        public float lerpStart = 30f;
        public float lerpEnd = 5f;
        public Quaternion initRot;
        public Quaternion answerRot;
    }
}
