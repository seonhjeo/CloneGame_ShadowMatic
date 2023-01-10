using UnityEngine;
using UnityEngine.EventSystems;

namespace Rotate
{
    public partial class RevoluteRotate // Properties and Methods that other classes can use
    {
        // IRotate properties
        public RotateTypes Type { get; } = RotateTypes.Revoluter;
        
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
        public void ActivateObject(bool active) => _ActivateObject(active);
        public float ReturnProgress() => _ReturnProgress();
    }

    public partial class RevoluteRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        private BoxCollider _myCollider;

        private ObjectRotate[] _childRotates;
        private short _activeChild;
    }

    public partial class RevoluteRotate : MonoBehaviour
    {
        private void Awake()
        {
            _childRotates = GetComponentsInChildren<ObjectRotate>();
            _myRigidBody = gameObject.GetComponent<Rigidbody>();
            _myCollider = gameObject.GetComponent<BoxCollider>();
        }

        private void Start()
        {
            _Init();
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
        private void _Init()
        {
            _activeChild = -1;
            _ActivateObject(false);
        }
        
        private void _ActivateObject(bool active)
        {
            _myRigidBody.isKinematic = !active;
            _myCollider.enabled = active;

            if (active == false)
            {
                _ChangeActiveChild();
            }
            else
            {
                foreach (ObjectRotate child in _childRotates)
                {
                    child.ActivateObject(false);
                }
            }
            
        }

        private void _ChangeActiveChild()
        {
            _activeChild += 1;
            if (_activeChild >= _childRotates.Length)
            {
                _activeChild = 0;
            }

            for (int i = 0; i < _childRotates.Length; i++)
            {
                if (i == _activeChild)
                {
                    _childRotates[i].ActivateObject(true);
                }
                else
                {
                    _childRotates[i].ActivateObject(false);
                }
            }
        }
        
        private float _ReturnProgress()
        {
            return 0f;
        }
    }
}