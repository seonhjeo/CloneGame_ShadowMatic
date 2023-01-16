using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

using ScriptableObj;

namespace Rotate
{
    public partial class ObjectRotate // Properties and Methods that other classes can use
    {
        // IRotate properties
        public RotateTypes Type { get; } = RotateTypes.Object;

        public void InitObj() => _InitObj();
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
        public void ActivateObject(bool active) => _ActivateObject(active);
        public float ReturnProgress() => _ReturnProgress();
        public void RotateObjToAns(float time) => _RotateObjToAns(time);
    }

    public partial class ObjectRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        private BoxCollider _myCollider;

        [SerializeField]
        private ObjectSo objectData;
    }

// Class Body
    public partial class ObjectRotate : MonoBehaviour
    {
        private void Awake()
        {
            _myRigidBody = gameObject.GetComponent<Rigidbody>();
            _myCollider = gameObject.GetComponent<BoxCollider>();
        }
    }

    public partial class ObjectRotate : IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            float x = 0, y, z = 0;
            
            if (Input.GetButton("RotYaw"))
            {
                y = eventData.delta.y;
                z = eventData.delta.x;
            }
            else
            {
                x = eventData.delta.x;
                y = eventData.delta.y;
            }

            _RotateObj(x, y, z);
        }
    }

    public partial class ObjectRotate : IRotate
    {
        private void _InitObj()
        {
            transform.rotation = objectData.initRot;
        }
        
        private void _RotateObj(float x, float y, float z)
        {
            _myRigidBody.AddTorque(y, -x, -z);
        }
        
        private void _ActivateObject(bool active)
        {
            _myRigidBody.isKinematic = !active;
            _myCollider.enabled = active;
        }

        private float _ReturnProgress()
        {
            float angle = Quaternion.Angle(transform.rotation, objectData.answerRot);
            
            float res = Mathf.InverseLerp(objectData.lerpStart, objectData.lerpEnd, angle);
            res = Mathf.Pow(res, 3);

            return res;
        }
        
        private void _RotateObjToAns(float time)
        {
            StartCoroutine(RotObjAns(time));
        }

        IEnumerator RotObjAns(float time)
        {
            float elapsedTime = 0;
            Quaternion cur = transform.rotation;

            while (elapsedTime < time)
            {
                transform.rotation = Quaternion.Slerp(cur, objectData.answerRot, elapsedTime / time);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.rotation = objectData.answerRot;
        }
    }
}