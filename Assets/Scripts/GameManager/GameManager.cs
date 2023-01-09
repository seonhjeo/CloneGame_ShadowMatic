using System.Collections.Generic;
using Rotate;
using UnityEngine;

namespace GameManager
{
    public partial class GameManager // Properties and Methods that other classes can use
    {
    }

    public partial class GameManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private List<GameObject> rotObjs = new List<GameObject>();

        private GameObject _curObj;
        private IRotate _curRot;
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = GameObject.Instantiate(rotObjs[0], new Vector3(0f, 0f, -7f), Quaternion.identity);
            _curRot = _curObj.GetComponent<IRotate>();
        }

        private void Update()
        {
            _SetRevolute();
        }
    }

    //class body
    public partial class GameManager
    {
        // Control Input
        private void _SetRevolute()
        {
            if (_curRot.Type == RotateTypes.Revoluter)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    _curRot.ActivateRigidBody(true);
                }
                else if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    _curRot.ActivateRigidBody(false);
                }
            }
        }
    }
}

