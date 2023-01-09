using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class RevoluteRotate // Properties and Methods that other classes can use
    {
        // IRotate properties
        public RotateTypes Type { get; } = RotateTypes.Revoluter;
        
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
        public void ActivateRigidBody(bool active) => _ActivateRigidBody(active);
        public float ReturnProgress() => _ReturnProgress();
    }

    public partial class RevoluteRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        private BoxCollider _myCollider;

        private ObjectRotate[] _childRotates;
    }

    public partial class RevoluteRotate : MonoBehaviour
    {
        private void Awake()
        {
            _childRotates = GetComponentsInChildren<ObjectRotate>();
            _myRigidBody = gameObject.GetComponent<Rigidbody>();
            _myCollider = gameObject.GetComponent<BoxCollider>();
        }
    }

    public partial class RevoluteRotate : IDragHandler, IRotate
    {
        public void OnDrag(PointerEventData eventData)
        {
            float x = 0, y, z = 0;

            // TODO : Associate with GameManager to control KeyInput
            if (Input.GetKey(KeyCode.LeftControl))
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

        private void _RotateObj(float x, float y, float z)
        {
            _myRigidBody.AddTorque(y, -x, -z);
        }
    }
    
    public partial class RevoluteRotate
    {
        private void _ActivateRigidBody(bool active)
        {
            _myRigidBody.isKinematic = !active;
            _myCollider.enabled = active;
            foreach (ObjectRotate child in _childRotates)
            {
                child.ActivateRigidBody(!active);
            }
        }

        private void _ChangeActiveChild()
        {
            foreach (ObjectRotate child in _childRotates)
            {
                // ...
            }
        }
        
        private float _ReturnProgress()
        {
            return 0f;
        }
    }
}