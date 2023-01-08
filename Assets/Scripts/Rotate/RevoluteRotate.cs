using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class RevoluteRotate // Properties and Methods that other classes can use
    {

    }

    public partial class RevoluteRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        
        private ObjectRotate[] _childRotates;
        private Rigidbody[] _childRigidBody;

        public void OnDrag(PointerEventData eventData) => _OnDrag(eventData);
    }

    public partial class RevoluteRotate : MonoBehaviour
    {
        private void Awake()
        {
            _childRotates = GetComponentsInChildren<ObjectRotate>();
            _childRigidBody = GetComponentsInChildren<Rigidbody>();
            _myRigidBody = gameObject.GetComponent<Rigidbody>();
        }
    }

    public partial class RevoluteRotate : IDragHandler
    {
        private void _OnDrag(PointerEventData eventData)
        {
            float x = 0, y, z = 0;

            // TODO : Associate with GameManager to control KeyInput
            if (Input.GetKey(KeyCode.LeftShift))
            {
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

                _myRigidBody.AddTorque(y, -x, -z);
                foreach (ObjectRotate child in _childRotates)
                {
                    child.RotateObj(y, -x, -z);
                }
            }
        }

        private void _ActivateChildRigidBody(bool active)
        {
            foreach (Rigidbody child in _childRigidBody)
            {
                child.isKinematic = active;
            }
        }
    }
}