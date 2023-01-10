using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class ObjectRotate // Properties and Methods that other classes can use
    {
        // IRotate properties
        public RotateTypes Type { get; } = RotateTypes.Object;

        public void InitObj(Vector3 startRot, Vector3 answerRot) => _InitObj(startRot, answerRot);
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
        public void ActivateObject(bool active) => _ActivateObject(active);
        public float ReturnProgress() => _ReturnProgress();
    }

    public partial class ObjectRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        private BoxCollider _myCollider;

        private Quaternion _answerRot;
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

            // TODO : Associate with GameManager to control KeyInput
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
        private void _InitObj(Vector3 startRot, Vector3 answerRot)
        {
            _answerRot = Quaternion.Euler(answerRot);
            transform.rotation = Quaternion.Euler(startRot);
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
            float angle = Quaternion.Angle(transform.rotation, _answerRot);
            // TODO : Lerp angle from 0 to 1
            
            return angle;
        }
    }
}