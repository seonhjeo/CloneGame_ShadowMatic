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

        // TODO : store in Json and pop into scriptableObj
        private readonly Vector3 _initVec = new Vector3(0f, 0f, -7f);
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = Instantiate(rotObjs[2], _initVec, Quaternion.identity);
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
                if (Input.GetButtonDown("Revolute"))
                {
                    _curRot.ActivateObject(true);
                }
                else if (Input.GetButtonUp("Revolute"))
                {
                    _curRot.ActivateObject(false);
                }
            }
        }
    }
}

