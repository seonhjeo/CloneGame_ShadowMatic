using System.Collections;

using UnityEngine;
using UnityEngine.EventSystems;

using Data;
using ScriptableObj;

namespace Rotate
{
    public partial class RevoluteRotate // Properties and Methods that other classes can use
    {
        // IRotate properties
        public RotateTypes Type { get; } = RotateTypes.Revoluter;
        
        public void InitObj() => _InitObj();
        public void RotateObj(float x, float y, float z) => _RotateObj(x, y, z);
        public void ActivateObject(bool active) => _ActivateObject(active);
        public float ReturnProgress() => _ReturnProgress();
        public void RotateObjToAns(float time) => _RotateObjToAns(time);
    }

    public partial class RevoluteRotate // Properties and Methods that only this class use
    {
        private Rigidbody _myRigidBody;
        private BoxCollider _myCollider;

        private ObjectRotate[] _childRotates;
        private short _activeChild;

        [SerializeField]
        private ObjectSo objectData;
        //private Quaternion _answerRot;
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
            float t = DataManager.Instance.PlayerData.MouseSensitivity;
            _myRigidBody.AddTorque(y * t, -x * t, -z * t);
        }
    }
    
    public partial class RevoluteRotate
    {
        private void _Init()
        {
            _activeChild = -1;
            _ActivateObject(false);
        }
        
        private void _InitObj()
        {
            transform.rotation = objectData.initRot;
            foreach (ObjectRotate child in _childRotates)
            {
                child.InitObj();
            }
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
                bool temp = (i == _activeChild);
                _childRotates[i].ActivateObject(temp);
            }
        }
        
        private float _ReturnProgress()
        {
            float angle = Quaternion.Angle(transform.rotation, objectData.answerRot);
            float res = Mathf.InverseLerp(objectData.lerpStart, objectData.lerpEnd, angle);
            res = Mathf.Pow(res, 3);
            
            
            foreach (ObjectRotate child in _childRotates)
            {
                res += child.ReturnProgress();
            }

            return res / (_childRotates.Length + 1);
        }

        private void _RotateObjToAns(float time)
        {
            StartCoroutine(RotObjAns(time));
            
            foreach (ObjectRotate child in _childRotates)
            {
                child.RotateObjToAns(time);
            }
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