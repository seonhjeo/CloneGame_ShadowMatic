using UnityEngine;

namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "GameManager Data", menuName = "Scriptable Object/GameManager Data")]
    public class GameManagerSo : ScriptableObject
    {
        public Vector3 objectPos = new Vector3(0, 0, -7f);
        public float Offset = 0.999f;
        public float AnswerLerpTime = 3f;
    }
}


