using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

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

        [SerializeField]
        private UnityEvent onPlayerClear;

        private GameObject _curObj;
        private IRotate _curRot;

        private bool _getClear;
        private DateTime _time;
    }

    public partial class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            _curObj = Instantiate(rotObjs[2], gameData.objectPos, Quaternion.identity);
            _curRot = _curObj.GetComponent<IRotate>();
            _getClear = false;
        }

        private void Start()
        {
            _curRot.InitObj();
            _time = DateTime.Now;
        }
        
        private void Update()
        {
            if (!_getClear)
            {
                _SetRevolute();
                _CheckClear();
            }
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
                _getClear = true;
                TimeSpan timeSpan = DateTime.Now - _time;
                // TODO : Indicate Time
                Debug.Log(timeSpan);
                
                onPlayerClear.Invoke();
                _curRot.RotateObjToAns(gameData.AnswerLerpTime);
            }
        }
    }
}

