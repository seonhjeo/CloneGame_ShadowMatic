using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class RevoluteRotate // Properties and Methods that other classes can use
    {

    }

    public partial class RevoluteRotate // Properties and Methods that only this class use
    {
        private const float RotateSpeed = 100f;

        private ObjectRotate[] _childObjects;

        public void OnDrag(PointerEventData eventData) => _OnDrag(eventData);
    }

    public partial class RevoluteRotate : MonoBehaviour
    {
        private void Awake()
        {
            _childObjects = GetComponentsInChildren<ObjectRotate>();
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

                _RotateObj(x, y, z);
                foreach (ObjectRotate child in _childObjects)
                {
                    child.RotateObj(-x, -y, -z);
                }
            }
        }

        private void _RotateObj(float x, float y, float z)
        {
            float offset = Time.deltaTime * RotateSpeed;

            transform.Rotate(Vector3.up, -x * offset, Space.World);
            transform.Rotate(Vector3.left, -y * offset, Space.World);
            transform.Rotate(Vector3.forward, -z * offset, Space.World);
        }
    }
}