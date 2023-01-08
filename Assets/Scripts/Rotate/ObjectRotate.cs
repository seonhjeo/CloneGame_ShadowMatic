using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class ObjectRotate // Properties and Methods that other classes can use
    {
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
    }

    public partial class ObjectRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
    }

// Class Body
    public partial class ObjectRotate : MonoBehaviour
    {
        private void Awake()
        {
            _myRigidBody = gameObject.GetComponent<Rigidbody>();
        }
    }

    public partial class ObjectRotate : IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            float x = 0, y, z = 0;

            // TODO : Associate with GameManager to control KeyInput
            if (!Input.GetKey(KeyCode.LeftShift))
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
            }
        }

        private void _RotateObj(float x, float y, float z)
        {
            // OPT : Rotate opposite direction of Revoluter
        }
    }
}