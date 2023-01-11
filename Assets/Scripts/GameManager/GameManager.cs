using System.Collections.Generic;
using UnityEngine;

using Rotate;
using ScriptableObj;

namespace GameManager
{
    public partial class GameManager // Properties and Methods that other classes can use
    {
    }

    public partial class GameManager // Properties and Methods that only this class use
    {
        [SerializeField]
        private GameManagerSo gameData;
        
        [SerializeField]
        private List<GameObject> rotObjs = new List<GameObject>();

        private GameObject _curObj;
        private IRotate _curRot;

        //private readonly Vector3 _initVec = new Vector3(0f, 0f, -7f);
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = Instantiate(rotObjs[0], gameData.objectPos, Quaternion.identity);
            _curRot = _curObj.GetComponent<IRotate>();
        }

        private void Start()
        {
            _curRot.InitObj();
        }
        
        private void Update()
        {
            _SetRevolute();
            _CheckClear();
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

        private void _CheckClear()
        {
            float res = _curRot.ReturnProgress();
            // TODO : Indicate res
            if (res >= gameData.Offset)
            {
                // TODO : Deactivate object and Show result
            }
        }
    }
}

